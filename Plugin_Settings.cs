
using Newtonsoft.Json;
using Quokka.ListItems;
using Quokka.PluginArch;
using System.IO;
using WinCopies.Util;

namespace Plugin_Settings {

  /// <summary>
  /// The settings plugin
  /// </summary>
  public partial class Settings : Plugin {

    private static PluginSettings pluginSettings = new();
    internal static PluginSettings PluginSettings { get => pluginSettings; set => pluginSettings = value; }

    /// <summary>
    /// Loads plugin settings
    /// </summary>
    public Settings() {
      string fileName = Environment.CurrentDirectory + "\\PlugBoard\\Plugin_Settings\\Plugin\\settings.json";
      PluginSettings = JsonConvert.DeserializeObject<PluginSettings>(File.ReadAllText(fileName))!;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override string PluggerName { get; set; } = "Settings";

    enum settingsType {
      WindowsSettings, ControlPanelSettings, Either
    }

    private List<ListItem> loadItems(string query, settingsType type) {
      List<ListItem> items = new();
      switch (type) {
        case settingsType.WindowsSettings:
          for (int i = 0; i < allSettings.Count; i++) {
            if (allSettings[i][0].Contains(query, StringComparison.OrdinalIgnoreCase)
            || ( FuzzySearch.LD(allSettings[i][0], query) < PluginSettings.FuzzySearchThreshold )) {
              items.Add(new WindowsSettingsItem(i, allSettings[i][0], allSettings[i][1]));
            }
          }
          break;
        case settingsType.ControlPanelSettings:
          for (int i = 0; i < allCplPages.Count; i++) {
            if (allCplPages[i][0].Contains(query, StringComparison.OrdinalIgnoreCase)
            || ( FuzzySearch.LD(allCplPages[i][0], query) < PluginSettings.FuzzySearchThreshold )) {
              items.Add(new ControlPanelPageItem(allCplPages[i][0], allCplPages[i][1], allCplPages[i][2]));
            }
          }
          break;
        default:
          for (int i = 0; i < allSettings.Count; i++) {
            if (allSettings[i][0].Contains(query, StringComparison.OrdinalIgnoreCase)
            || ( FuzzySearch.LD(allSettings[i][0], query) < PluginSettings.FuzzySearchThreshold )) {
              items.Add(new WindowsSettingsItem(i, allSettings[i][0], allSettings[i][1]));
            }
          }
          for (int i = 0; i < allCplPages.Count; i++) {
            if (allCplPages[i][0].Contains(query, StringComparison.OrdinalIgnoreCase)
            || ( FuzzySearch.LD(allCplPages[i][0], query) < PluginSettings.FuzzySearchThreshold )) {
              items.Add(new ControlPanelPageItem(allCplPages[i][0], allCplPages[i][1], allCplPages[i][2]));
            }
          }
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
    public override List<ListItem> OnQueryChange(string query) { return loadItems(query, settingsType.Either); }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns>
    /// The signifiers from plugin settings (SettingsSignifier, EitherSettingsTypeSignifier, ControlPanelSignifier)
    /// </returns>
    public override List<string> CommandSignifiers() {
      return new List<string>() { PluginSettings.SettingsSignifier, PluginSettings.EitherSettingsTypeSignifier, PluginSettings.ControlPanelSignifier };
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <param name="command">A command signifier for this plugin, followed by the settings page being searched for</param>
    /// <returns>List of settings pages that possibly match what is being searched for</returns>
    public override List<ListItem> OnSignifier(string command) {
      if (command.StartsWith(PluginSettings.SettingsSignifier)) {
        command = command.Substring(PluginSettings.SettingsSignifier.Length);
        return loadItems(command, settingsType.WindowsSettings);
      } else if (command.StartsWith(PluginSettings.ControlPanelSignifier)) {
        command = command.Substring(PluginSettings.ControlPanelSignifier.Length);
        return loadItems(command, settingsType.ControlPanelSettings);
      } else {
        command = command.Substring(PluginSettings.EitherSettingsTypeSignifier.Length);
        return loadItems(command, settingsType.Either);
      }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <returns>The commands in settings (AllWindowsSettingsCommand, AllControlPanelSettingsCommand, AllSettingsCommand)</returns>
    public override List<String> SpecialCommands() {
      return new List<String>() { PluginSettings.AllWindowsSettingsCommand, PluginSettings.AllControlPanelSettingsCommand, PluginSettings.AllSettingsCommand };
    }

    /// <summary>
    /// <inheritdoc/><br />
    /// Provides all the settings pages for the relevant special command
    /// </summary>
    /// <param name="command"><inheritdoc/></param>
    /// <returns>all the relevant settings pages</returns>
    public override List<ListItem> OnSpecialCommand(string command) {
      switch (command) {
        case var value when value == PluginSettings.AllWindowsSettingsCommand:
          List<ListItem> items = new List<ListItem>() { };
          for (int i = 0; i < allSettings.Count; i++) {
            items.Add(new WindowsSettingsItem(i, allSettings[i][0], allSettings[i][1]));
          }
          return items;
        case var value when value == PluginSettings.AllControlPanelSettingsCommand:
          items = new List<ListItem>() { };
          for (int i = 0; i < allCplPages.Count; i++) {
            items.Add(new ControlPanelPageItem(allCplPages[i][0], allCplPages[i][1], allCplPages[i][2]));
          }
          return items;
        default:
          items = new List<ListItem>() { };
          for (int i = 0; i < allSettings.Count; i++) {
            items.Add(new WindowsSettingsItem(i, allSettings[i][0], allSettings[i][1]));
          }
          for (int i = 0; i < allCplPages.Count; i++) {
            items.Add(new ControlPanelPageItem(allCplPages[i][0], allCplPages[i][1], allCplPages[i][2]));
          }
          return items;
      }
    }
  }

}
