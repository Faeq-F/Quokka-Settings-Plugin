namespace PluginSettings
{
  /// <summary>
  /// All plugin specific settings
  /// </summary>
  public class PluginSettings
  {
    /// <summary>
    /// The command signifier used to obtain only Windows Settings Pages (defaults to "* ")<br />
    /// Using this signifier does not change the output of this plugin, it only
    /// ensures that no other plugins' results are included in the search window results list
    /// </summary>
    public string SettingsSignifier { get; set; } = "* ";

    /// <summary>
    /// The command signifier used to obtain only Control Panel Pages (defaults to "&amp; ")<br />
    /// Using this signifier does not change the output of this plugin, it only
    /// ensures that no other plugins' results are included in the search window results list
    /// </summary>
    public string ControlPanelSignifier { get; set; } = "& ";

    /// <summary>
    /// The command signifier used to obtain only Windows Settings Pages or Control Panel Pages (defaults to "~ ")<br />
    /// Using this signifier does not change the output of this plugin, it only
    /// ensures that no other plugins' results are included in the search window results list
    /// </summary>
    public string EitherSettingsTypeSignifier { get; set; } = "~ ";
    /// <summary>
    ///   The command to show all Windows Settings Pages
    ///   (defaults to 'AllWindowsSettings')
    /// </summary>
    public string AllWindowsSettingsCommand { get; set; } = "AllWindowsSettings";
    /// <summary>
    ///   The command to show all Control Panel Pages
    ///   (defaults to 'AllControlPanelSettings')
    /// </summary>
    public string AllControlPanelSettingsCommand { get; set; } = "AllControlPanelSettings";
    /// <summary>
    ///   The command to show all Settings Pages (Windows Settings or Control Panel)
    ///   (defaults to 'AllSettings')
    /// </summary>
    public string AllSettingsCommand { get; set; } = "AllSettings";
    /// <summary>
    ///   The threshold for when to consider a settings page
    ///   name is similar enough to the query for it to be
    ///   displayed (defaults to 70). The larger the number, the
    ///   more similar it needs to be.
    /// </summary>
    public int FuzzySearchThreshold { get; set; } = 70;

  }
}
