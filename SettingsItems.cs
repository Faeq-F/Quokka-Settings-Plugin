using Quokka;
using Quokka.ListItems;
using System.Diagnostics;
using System.Windows.Media.Imaging;

namespace Plugin_Settings {

  public partial class Settings {

    internal static List<List<string>> allSettings = new() {

      # region Accounts

      new(){ "Access work or school", "ms-settings:workplace" },
      new(){ "Email & app accounts", "ms-settings:emailandaccounts" },
      new(){ "Family & other people", "ms-settings:otherusers" },
      new(){ "Sign-in options", "ms-settings:signinoptions" },
      new(){ "Sync your settings", "ms-settings:sync" },
      new(){ "Your info", "ms-settings:yourinfo" },

      # endregion

      #region Apps

      new(){ "Apps & Features", "ms-settings:appsfeatures" },
      new(){ "Apps for websites", "ms-settings:appsforwebsites" },
      new(){ "Default apps", "ms-settings:defaultapps" },
      new(){ "Manage optional features", "ms-settings:optionalfeatures" },
      new(){ "Offline Maps", "ms-settings:maps" },
      new(){ "Startup apps", "ms-settings:startupapps" },
      new(){ "Video playback", "ms-settings:videoplayback" },

      #endregion

      #region Devices

      new(){ "AutoPlay", "ms-settings:autoplay" },
      new(){ "Bluetooth", "ms-settings:bluetooth" },
      new(){ "Connected Devices", "ms-settings:connecteddevices" },
      new(){ "Camera settings", "ms-settings:camera" },
      new(){ "Mouse & touchpad", "ms-settings:mousetouchpad" },
      new(){ "Pen & Windows Ink", "ms-settings:pen" },
      new(){ "Printers & scanners", "ms-settings:printers" },
      new(){ "Typing", "ms-settings:typing" },
      new(){ "USB", "ms-settings:usb" },
      new(){ "Your phone", "ms-settings:mobile-devices" },

      #endregion

      #region Ease of Access

      new(){ "Audio", "ms-settings:easeofaccess-audio" },
      new(){ "Closed captions", "ms-settings:easeofaccess-closedcaptioning" },
      new(){ "Color filters", "ms-settings:easeofaccess-colorfilter" },
      new(){ "Display", "ms-settings:easeofaccess-display" },
      new(){ "Eye control", "ms-settings:easeofaccess-eyecontrol" },
      new(){ "High contrast", "ms-settings:easeofaccess-highcontrast" },
      new(){ "Keyboard", "ms-settings:easeofaccess-keyboard" },
      new(){ "Magnifier", "ms-settings:easeofaccess-magnifier" },
      new(){ "Mouse", "ms-settings:easeofaccess-mouse" },
      new(){ "Mouse pointer & touch", "ms-settings:easeofaccess-mousepointer" },
      new(){ "Narrator", "ms-settings:easeofaccess-narrator" },
      new(){ "Speech", "ms-settings:easeofaccess-speechrecognition" },
      new(){ "Text cursor", "ms-settings:easeofaccess-cursor" },
      new(){ "Visual Effects", "ms-settings:easeofaccess-visualeffects" },

      #endregion

      #region Family Group

      new(){ "Family Group", "ms-settings:family-group" },

      #endregion

      #region Gaming

      new(){ "Game bar", "ms-settings:gaming-gamebar" },
      new(){ "Game DVR", "ms-settings:gaming-gamedvr" },
      new(){ "Game Mode", "ms-settings:gaming-gamemode" },

      #endregion

      #region Network and Internet

      new(){ "Network & internet", "ms-settings:network-status" },
      new(){ "Advanced settings", "ms-settings:network-advancedsettings" },
      new(){ "Airplane mode", "ms-settings:network-airplanemode" },
      new(){ "Cellular & SIM", "ms-settings:network-cellular" },
      new(){ "Dial-up", "ms-settings:network-dialup" },
      new(){ "Ethernet", "ms-settings:network-ethernet" },
      new(){ "Manage known networks", "ms-settings:network-wifisettings" },
      new(){ "Mobile hotspot", "ms-settings:network-mobilehotspot" },
      new(){ "Proxy", "ms-settings:network-proxy" },
      new(){ "VPN", "ms-settings:network-vpn" },
      new(){ "Wi-Fi", "ms-settings:network-wifi" },

      #endregion

      #region Personalization

      new(){ "Background", "ms-settings:personalization-background" },
      new(){ "Choose which folders appear on Start", "ms-settings:personalization-start-places" },
      new(){ "Colors", "ms-settings:personalization-colors" },
      new(){ "Dynamic Lighting", "ms-settings:personalization-lighting" },
      new(){ "Fonts", "ms-settings:fonts" },
      new(){ "Lock screen", "ms-settings:lockscreen" },
      new(){ "Personalization (category)", "ms-settings:personalization" },
      new(){ "Start", "ms-settings:personalization-start" },
      new(){ "Taskbar", "ms-settings:taskbar" },
      new(){ "Touch Keyboard", "ms-settings:personalization-touchkeyboard" },
      new(){ "Themes", "ms-settings:themes" },

      #endregion

      #region Phone

      new(){ "Your phone", "ms-settings:mobile-devices" },
      new(){ "Device Usage", "ms-settings:deviceusage" },

      #endregion

      #region Privacy

      new(){ "Account info", "ms-settings:privacy-accountinfo" },
      new(){ "Activity history", "ms-settings:privacy-activityhistory" },
      new(){ "App diagnostics", "ms-settings:privacy-appdiagnostics" },
      new(){ "Automatic file downloads", "ms-settings:privacy-automaticfiledownloads" },
      new(){ "Calendar", "ms-settings:privacy-calendar" },
      new(){ "Call history", "ms-settings:privacy-callhistory" },
      new(){ "Camera", "ms-settings:privacy-webcam" },
      new(){ "Contacts", "ms-settings:privacy-contacts" },
      new(){ "Documents", "ms-settings:privacy-documents" },
      new(){ "Downloads folder", "ms-settings:privacy-downloadsfolder" },
      new(){ "Email", "ms-settings:privacy-email" },
      new(){ "Feedback & diagnostics", "ms-settings:privacy-feedback" },
      new(){ "File system", "ms-settings:privacy-broadfilesystemaccess" },
      new(){ "General", "ms-settings:privacy" },
      new(){ "Graphics", "ms-settings:privacy-graphicscaptureprogrammatic " },
      new(){ "Inking & typing", "ms-settings:privacy-speechtyping" },
      new(){ "Location", "ms-settings:privacy-location" },
      new(){ "Messaging", "ms-settings:privacy-messaging" },
      new(){ "Microphone", "ms-settings:privacy-microphone" },
      new(){ "Music Library", "ms-settings:privacy-musiclibrary" },
      new(){ "Notifications", "ms-settings:privacy-notifications" },
      new(){ "Other devices", "ms-settings:privacy-customdevices" },
      new(){ "Phone calls", "ms-settings:privacy-phonecalls" },
      new(){ "Pictures", "ms-settings:privacy-pictures" },
      new(){ "Radios", "ms-settings:privacy-radios" },
      new(){ "Speech", "ms-settings:privacy-speech" },
      new(){ "Tasks", "ms-settings:privacy-tasks" },
      new(){ "Videos", "ms-settings:privacy-videos" },
      new(){ "Voice activation", "ms-settings:privacy-voiceactivation" },

      #endregion

      #region Search

      new(){ "Search", "ms-settings:search" },
      new(){ "Search Permissions", "ms-settings:search-permissions" },

      #endregion

      #region Sound

      new(){ "page", "ms-settings:apps-volume" },
      new(){ "page", "ms-settings:sound" },
      new(){ "page", "ms-settings:sound-devices" },

      #endregion

      #region System

      new(){ "About", "ms-settings:about" },
      new(){ "Advanced display settings", "ms-settings:display-advanced" },
      new(){ "Battery Saver", "ms-settings:batterysaver" },
      new(){ "Battery Saver settings", "ms-settings:batterysaver-settings" },
      new(){ "Battery use", "ms-settings:batterysaver-usagedetails" },
      new(){ "Clipboard", "ms-settings:clipboard" },
      new(){ "Display", "ms-settings:display" },
      new(){ "Default Save Locations", "ms-settings:savelocations" },
      new(){ "Display", "ms-settings:screenrotation" },
      new(){ "Duplicating my display", "ms-settings:quietmomentspresentation" },
      new(){ "During these hours", "ms-settings:quietmomentsscheduled" },
      new(){ "Encryption", "ms-settings:deviceencryption" },
      new(){ "Energy recommendations", "ms-settings:energyrecommendations" },
      new(){ "Focus assist", "ms-settings:quiethours" },
      new(){ "Graphics Settings", "ms-settings:display-advancedgraphics" },
      new(){ "Graphics Default Settings", "ms-settings:display-advancedgraphics-default" },
      new(){ "Multitasking", "ms-settings:multitasking" },
      new(){ "Night light settings", "ms-settings:nightlight" },
      new(){ "Projecting to this PC", "ms-settings:project" },
      new(){ "Shared experiences", "ms-settings:crossdevice" },
      new(){ "Notifications & actions", "ms-settings:notifications" },
      new(){ "Remote Desktop", "ms-settings:remotedesktop" },
      new(){ "Power & sleep", "ms-settings:powersleep" },
      new(){ "Presence sensing", "ms-settings:presence" },
      new(){ "Storage", "ms-settings:storagesense" },
      new(){ "Storage Sense", "ms-settings:storagepolicies" },
      new(){ "Storage recommendations", "ms-settings:storagerecommendations" },
      new(){ "Disks & volumes", "ms-settings:disksandvolumes" },

      #endregion

      #region Time and Language

      new(){ "Date & time", "ms-settings:dateandtime" },
      new(){ "Region", "ms-settings:regionformatting" },
      new(){ "Language", "ms-settings:keyboard" },
      new(){ "Speech", "ms-settings:speech" },

      #endregion

      #region Update and Security

      new(){ "Activation", "ms-settings:activation" },
      new(){ "Backup", "ms-settings:backup" },
      new(){ "Delivery Optimization", "ms-settings:delivery-optimization " },
      new(){ "Find My Device", "ms-settings:findmydevice" },
      new(){ "For developers", "ms-settings:developers" },
      new(){ "Recovery", "ms-settings:recovery" },
      new(){ "Troubleshoot", "ms-settings:troubleshoot" },
      new(){ "Windows Security", "ms-settings:windowsdefender" },
      new(){ "Windows Insider Program", "ms-settings:windowsinsider" },
      new(){ "Windows Update", "ms-settings:windowsupdate" },
      new(){ "Windows Update - Active hours", "ms-settings:windowsupdate-activehours" },
      new(){ "Windows Update - Advanced options", "ms-settings:windowsupdate-options" },
      new(){ "Windows Update - Optional updates", "ms-settings:windowsupdate-optionalupdates" },
      new(){ "Windows Update - View update history", "ms-settings:windowsupdate-history" },

      #endregion

    };

  }



  class WindowsSettingsItem : ListItem {

    private string uri;

    public WindowsSettingsItem(int index, string page, string uri) {
      string category = getCategory(index);
      Name = $"{category} | {page}";
      Description = $"Opens the '{page}' page in settings";
      Icon = new BitmapImage(new Uri(
          Environment.CurrentDirectory + "\\PlugBoard\\Plugin_Settings\\Plugin\\settings.png"));
      this.uri = uri;
    }

    public override void Execute() {
      Process.Start(uri);
      App.Current.MainWindow.Close();
    }

    private static string getCategory(int index) {
      if (index >= 0 && index <= 5) {
        return "Accounts";
      } else if (index >= 6 && index <= 12) {
        return "Apps";
      } else if (index >= 13 && index <= 22) {
        return "Devices";
      } else if (index >= 23 && index <= 36) {
        return "Ease of Access";
      } else if (index == 37) {
        return "Family Group";
      } else if (index >= 38 && index <= 40) {
        return "Gaming";
      } else if (index >= 41 && index <= 51) {
        return "Network and Internet";
      } else if (index >= 52 && index <= 62) {
        return "Personalization";
      } else if (index >= 63 && index <= 64) {
        return "Phone";
      } else if (index >= 65 && index <= 93) {
        return "Privacy";
      } else if (index >= 94 && index <= 95) {
        return "Search";
      } else if (index >= 96 && index <= 98) {
        return "Sound";
      } else if (index >= 99 && index <= 126) {
        return "System";
      } else if (index >= 127 && index <= 130) {
        return "Time and Language";
      } else {
        return "Update and Security";
      }
    }
  }

}
