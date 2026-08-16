using PluginSettings;
using Quokka.ListItems;
using System.Collections.ObjectModel;
using System.IO;

namespace PluginSettings.Tests
{
  /// <summary>
  /// Integration and unit tests for the <see cref="Settings"/> plugin.
  /// </summary>
  public class TestPluginSettings : IDisposable
  {
    private readonly string _tempPath;
    private readonly string _originalCurrentDirectory;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestPluginSettings"/> class and prepares the sandboxed environment.
    /// </summary>
    public TestPluginSettings()
    {
      _originalCurrentDirectory = Environment.CurrentDirectory;

      // Clean up legacy directories from previous runs
      try
      {
        foreach (string dir in Directory.GetDirectories(_originalCurrentDirectory, "TempSettings_*"))
        {
          try
          {
            Directory.Delete(dir, recursive: true);
          }
          catch
          {
            // Ignore locked directories
          }
        }
      }
      catch
      {
        // Ignore errors during directory cleanup
      }

      _tempPath = Path.Combine(_originalCurrentDirectory, "TempSettings_" + Guid.NewGuid().ToString("N"));
      Directory.CreateDirectory(_tempPath);

      // Create target directory structure matching expected plugin path
      string targetPluginDir = Path.Combine(_tempPath, "PlugBoard", "PluginSettings", "Plugin");
      Directory.CreateDirectory(targetPluginDir);

      // Write default settings.json
      const string defaultSettingsJson = /*lang=json*/ @"
      {
        ""SettingsSignifier"": ""* "",
        ""ControlPanelSignifier"": ""& "",
        ""EitherSettingsTypeSignifier"": ""~ "",
        ""AllWindowsSettingsCommand"": ""AllWindowsSettings"",
        ""AllControlPanelSettingsCommand"": ""AllControlPanelSettings"",
        ""AllSettingsCommand"": ""AllSettings"",
        ""FuzzySearchThreshold"": 70
      }";
      File.WriteAllText(Path.Combine(targetPluginDir, "settings.json"), defaultSettingsJson);

      // Redirect CurrentDirectory
      Environment.CurrentDirectory = _tempPath;

      if (System.Windows.Application.Current == null)
      {
        _ = new System.Windows.Application();
      }
    }

    /// <summary>
    /// Verifies that the plugin correctly configures its command signifiers and special commands.
    /// </summary>
    [Fact]
    public void TestSettings_ConfiguresSignifiersAndSpecialCommands()
    {
      Settings plugin = new();
      plugin.CommandSignifiers().Should().BeEquivalentTo("* ", "~ ", "& ");
      plugin.SpecialCommands().Should().BeEquivalentTo("AllWindowsSettings", "AllControlPanelSettings", "AllSettings");
    }

    /// <summary>
    /// Verifies that the plugin returns matching settings pages for query changes.
    /// </summary>
    [Fact]
    public void TestSettings_QueriesWindowsAndControlPanelPages()
    {
      Settings plugin = new();

      // Querying "display" should match display-related settings
      Collection<ListItem> results = plugin.OnQueryChange("display");
      results.Should().NotBeEmpty();
      results.Any(x => x.Name.Contains("Display")).Should().BeTrue();
    }

    /// <summary>
    /// Verifies that command signifiers filter results correctly.
    /// </summary>
    [Fact]
    public void TestSettings_FiltersBySignifiers()
    {
      Settings plugin = new();

      // Windows settings only (* signifier)
      Collection<ListItem> windowsOnly = plugin.OnSignifier("* display");
      windowsOnly.Should().NotBeEmpty();

      // Control panel only (& signifier)
      Collection<ListItem> cplOnly = plugin.OnSignifier("& Mouse");
      cplOnly.Should().NotBeEmpty();
    }

    /// <summary>
    /// Verifies that special commands return all correct settings.
    /// </summary>
    [Fact]
    public void TestSettings_EvaluatesSpecialCommands()
    {
      Settings plugin = new();

      Collection<ListItem> allWindowsSettings = plugin.OnSpecialCommand("AllWindowsSettings");
      allWindowsSettings.Should().NotBeEmpty();

      Collection<ListItem> allCplSettings = plugin.OnSpecialCommand("AllControlPanelSettings");
      allCplSettings.Should().NotBeEmpty();
    }

    /// <summary>
    /// Restores the original current directory and cleans up the sandbox files.
    /// </summary>
    public void Dispose()
    {
      Environment.CurrentDirectory = _originalCurrentDirectory;
      try
      {
        if (Directory.Exists(_tempPath))
        {
          Directory.Delete(_tempPath, recursive: true);
        }
      }
      catch
      {
        // Ignore locked files
      }
      GC.SuppressFinalize(this);
    }
  }
}
