
using Newtonsoft.Json;
using Quokka.ListItems;
using Quokka.PluginArch;
using System.Collections.ObjectModel;
using System.IO;
using WinCopies.Util;

namespace PluginSettings
{

  /// <summary>
  /// The settings plugin
  /// </summary>
  public partial class Settings : Plugin
  {

    private static PluginSettings pluginSettings = new();
    internal static PluginSettings PluginSettings { get => pluginSettings; set => pluginSettings = value; }

    /// <summary>
    /// Loads plugin settings
    /// </summary>
    public Settings()
    {
      string fileName = Environment.CurrentDirectory + "\\PlugBoard\\PluginSettings\\Plugin\\settings.json";
      PluginSettings = JsonConvert.DeserializeObject<PluginSettings>(File.ReadAllText(fileName))!;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override string PluginName { get; set; } = "Settings";

    enum SettingsType
    {
      WindowsSettings, ControlPanelSettings, Either
    }

    private static Collection<ListItem> LoadItems(string query, SettingsType type)
    {
      Collection<ListItem> items = new();
      switch (type)
      {
        case SettingsType.WindowsSettings:
          items.AddRange(
          FuzzySearch.SearchAll(query, new Collection<string>(allSettings.Select(x => x[0]).ToList()), PluginSettings.FuzzySearchThreshold)
          // After getting the top results, make them ListItems
          .Select(x => (ListItem)new WindowsSettingsItem(x.Index, allSettings[x.Index][0], allSettings[x.Index][1])).Distinct().ToList());
          break;
        case SettingsType.ControlPanelSettings:
          items.AddRange(
          FuzzySearch.SearchAll(query, new Collection<string>(allCplPages.Select(x => x[0]).ToList()), PluginSettings.FuzzySearchThreshold)
          // After getting the top results, make them ListItems
          .Select(x => (ListItem)new ControlPanelPageItem(allCplPages[x.Index][0], allCplPages[x.Index][1], allCplPages[x.Index][2])).Distinct().ToList());
          break;
        default:
          items.AddRange(
            LoadItems(query, SettingsType.WindowsSettings).Concat(
            LoadItems(query, SettingsType.ControlPanelSettings)));
          break;
      }
      return items;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="query"><inheritdoc/></param>
    /// <returns>
    /// Any settings pages that match the query
    /// </returns>
    public override Collection<ListItem> OnQueryChange(string query) { return LoadItems(query, SettingsType.Either); }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns>
    /// The signifiers from plugin settings (SettingsSignifier, EitherSettingsTypeSignifier, ControlPanelSignifier)
    /// </returns>
    public override Collection<string> CommandSignifiers()
    {
      return new Collection<string>() { PluginSettings.SettingsSignifier, PluginSettings.EitherSettingsTypeSignifier, PluginSettings.ControlPanelSignifier };
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="command">A command signifier for this plugin, followed by the settings page being searched for</param>
    /// <returns>Collection of settings pages that possibly match what is being searched for</returns>
    public override Collection<ListItem> OnSignifier(string command)
    {
      command ??= "";
      if (command.StartsWith(PluginSettings.SettingsSignifier, StringComparison.Ordinal))
      {
        command = command.Substring(PluginSettings.SettingsSignifier.Length);
        return FuzzySearch.Sort(command, LoadItems(command, SettingsType.WindowsSettings));
      }
      else if (command.StartsWith(PluginSettings.ControlPanelSignifier, StringComparison.Ordinal))
      {
        command = command.Substring(PluginSettings.ControlPanelSignifier.Length);
        return FuzzySearch.Sort(command, LoadItems(command, SettingsType.ControlPanelSettings));
      }
      else
      {
        command = command.Substring(PluginSettings.EitherSettingsTypeSignifier.Length);
        return FuzzySearch.Sort(command, LoadItems(command, SettingsType.Either));
      }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns>The commands in settings (AllWindowsSettingsCommand, AllControlPanelSettingsCommand, AllSettingsCommand)</returns>
    public override Collection<String> SpecialCommands()
    {
      return new Collection<String>() { PluginSettings.AllWindowsSettingsCommand, PluginSettings.AllControlPanelSettingsCommand, PluginSettings.AllSettingsCommand };
    }

    /// <summary>
    /// <inheritdoc/><br />
    /// Provides all the settings pages for the relevant special command
    /// </summary>
    /// <param name="command"><inheritdoc/></param>
    /// <returns>all the relevant settings pages</returns>
    public override Collection<ListItem> OnSpecialCommand(string command)
    {
      switch (command)
      {
        case var value when value == PluginSettings.AllWindowsSettingsCommand:
          {
            Collection<ListItem> items = new();
            for (int i = 0; i < allSettings.Count; i++)
            {
              items.Add(new WindowsSettingsItem(i, allSettings[i][0], allSettings[i][1]));
            }
            return items;
          }
        case var value when value == PluginSettings.AllControlPanelSettingsCommand:
          {
            Collection<ListItem> items = new();
            for (int i = 0; i < allCplPages.Count; i++)
            {
              items.Add(new ControlPanelPageItem(allCplPages[i][0], allCplPages[i][1], allCplPages[i][2]));
            }
            return items;
          }
        default:
          {
            Collection<ListItem> items = new();
            for (int i = 0; i < allSettings.Count; i++)
            {
              items.Add(new WindowsSettingsItem(i, allSettings[i][0], allSettings[i][1]));
            }
            for (int i = 0; i < allCplPages.Count; i++)
            {
              items.Add(new ControlPanelPageItem(allCplPages[i][0], allCplPages[i][1], allCplPages[i][2]));
            }
            return items;
          }
      }
    }
  }

}
