using Quokka;
using Quokka.ListItems;
using System.Windows.Media.Imaging;

namespace Plugin_Settings {

  public partial class Settings {
    internal static string cplPath = System.IO.Path.Combine(Environment.SystemDirectory, "control.exe");
    internal static List<List<string>> allCplPages = new() {
      new(){"Action Center", "Microsoft.ActionCenter", "{BB64F8A7-BEE7-4E1A-AB8D-7D8273F7FDB6}"},
      new(){"Administrative Tools", "Microsoft.AdministrativeTools", "{D20EA4E1-3957-11d2-A40B-0C5020524153}"},
      new(){"AutoPlay", "Microsoft.AutoPlay", "{9C60DE1E-E5FC-40f4-A487-460851A8D915}"},
      new(){"Biometric Devices", "Microsoft.BiometricDevices", "{0142e4d0-fb7a-11dc-ba4a-000ffe7ab428}"},
      new(){"BitLocker Drive Encryption", "Microsoft.BitLockerDriveEncryption", "{D9EF8727-CAC2-4e60-809E-86F80A666C91}"},
      new(){"Color Management", "Microsoft.ColorManagement", "{B2C761C6-29BC-4f19-9251-E6195265BAF1}"},
      new(){"Credential Manager", "Microsoft.CredentialManager", "{1206F5F1-0569-412C-8FEC-3204630DFB70}"},
      new(){"Date and Time", "Microsoft.DateAndTime", "{E2E7934B-DCE5-43C4-9576-7FE4F75E7480}"},
      new(){"Default Programs", "Microsoft.DefaultPrograms", "{17cd9488-1228-4b2f-88ce-4298e93e0966}"},
      new(){"Device Manager", "Microsoft.DeviceManager", "{74246bfc-4c96-11d0-abef-0020af6b0b7a}"},
      new(){"Devices and Printers", "Microsoft.DevicesAndPrinters", "{A8A91A66-3A7D-4424-8D24-04E180695C7A}"},
      new(){"Display", "Microsoft.Display", "{C555438B-3C23-4769-A71F-B6D3D9B6053A}"},
      new(){"Ease of Access Center", "Microsoft.EaseOfAccessCenter", "{D555645E-D4F8-4c29-A827-D93C859C4F2A}"},
      new(){"File History", "Microsoft.FileHistory", "{F6B6E965-E9B2-444B-9286-10C9152EDBC5}"},
      new(){"Folder Options", "Microsoft.FolderOptions", "{6DFD7C5C-2451-11D3-A299-00C04F8EF6AF}"},
      new(){"Fonts", "Microsoft.Fonts", "{93412589-74D4-4E4E-AD0E-E0CB621440FD}"},
      new(){"Game Controllers", "Microsoft.GameControllers", "{259EF4B1-E6C9-4176-B574-481532C9BCE8}"},
      new(){"HomeGroup", "Microsoft.HomeGroup", "{67CA7650-96E6-4FDD-BB43-A8E774F73A57}"},
      new(){"Indexing Options", "Microsoft.IndexingOptions", "{87D66A43-7B11-4A28-9811-C86EE395ACF7}"},
      new(){"Infrared", "Microsoft.Infrared", "{A0275511-0E86-4ECA-97C2-ECD8F1221D08}"},
      new(){"Internet Options", "Microsoft.InternetOptions", "{A3DD4F92-658A-410F-84FD-6FBBBEF2FFFE}"},
      new(){"iSCSI Initiator", "Microsoft.iSCSIInitiator", "{A304259D-52B8-4526-8B1A-A1D6CECC8243}"},
      new(){"iSNS Server", "Microsoft.iSNSServer", "{0D2A3442-5181-4E3A-9BD4-83BD10AF3D76}"},
      new(){"Keyboard", "Microsoft.Keyboard", "{A6482830-08EB-41E2-84C1-733DC143A69E}"},
      new(){"Location and Other Sensors", "Microsoft.LocationAndOtherSensors", "{E9950154-C418-419e-A90A-20C5287AE24B}"},
      new(){"Mouse", "Microsoft.Mouse", "{6C8EEC18-8D75-41B2-A177-8831D59D2D50}"},
      new(){"MPIOConfiguration", "Microsoft.MPIOConfiguration", "{AB3BE6AA-7561-4838-AB77-ACF8427DF426}"},
      new(){"Network and Sharing Center", "Microsoft.NetworkAndSharingCenter", "{8E908FC9-BECC-40f6-915B-F4CA0E70D03D}"},
      new(){"Notification Area Icons", "Microsoft.NotificationAreaIcons", "{05d7b0f4-2121-4eff-bf6b-ed3f69b894d9}"},
      new(){"Pen and Touch", "Microsoft.PenAndTouch", "{F82DF8F7-8B9F-442E-A48C-818EA735FF9B}"},
      new(){"Personalization", "Microsoft.Personalization", "{ED834ED6-4B5A-4bfe-8F11-A626DCB6A921}"},
      new(){"Phone and Modem", "Microsoft.PhoneAndModem", "{40419485-C444-4567-851A-2DD7BFA1684D}"},
      new(){"Power Options", "Microsoft.PowerOptions", "{025A5937-A6BE-4686-A844-36FE4BEC8B6D}"},
      new(){"Programs and Features", "Microsoft.ProgramsAndFeatures", "{7b81be6a-ce2b-4676-a29e-eb907a5126c5}"},
      new(){"Recovery", "Microsoft.Recovery", "{9FE63AFD-59CF-4419-9775-ABCC3849F861}"},
      new(){"Region and Language", "Microsoft.RegionAndLanguage", "{62D8ED13-C9D0-4CE8-A914-47DD628FB1B0}"},
      new(){"RemoteApp and Desktop Connections", "Microsoft.RemoteAppAndDesktopConnections", "{241D7C96-F8BF-4F85-B01F-E2B043341A4B}"},
      new(){"Sound", "Microsoft.Sound", "{F2DDFC82-8F12-4CDD-B7DC-D4FE1425AA4D}"},
      new(){"Speech Recognition", "Microsoft.SpeechRecognition", "{58E3C745-D971-4081-9034-86E34B30836A}"},
      new(){"Storage Spaces", "Microsoft.StorageSpaces", "{F942C606-0914-47AB-BE56-1321B8035096}"},
      new(){"Sync Center", "Microsoft.SyncCenter", "{E9F5A5A1-8A92-4F95-A0B0-21280BE1812D}"},
      new(){"System", "Microsoft.System", "{BB06C0E4-D293-4f75-8A90-CB05B6477EEE}"},
      new(){"Tablet PC Settings", "Microsoft.TabletPCSettings", "{F2DDFC82-8F12-4CDD-B7DC-D4FE1425AA4D}"},
      new(){"Taskbar and Navigation", "Microsoft.TaskbarAndNavigation", "{0DF44EAA-FF21-4412-828E-260A8728E7F1}"},
      new(){"Troubleshooting", "Microsoft.Troubleshooting", "{C58C4893-3BE0-4B45-ABB5-A63E4B8C8651}"},
      new(){"User Accounts", "Microsoft.UserAccounts", "{60632754-c523-4b62-b45c-4172da012619}"},
      new(){"Windows Defender", "Microsoft.WindowsDefender", "{D8559EB9-20C0-410E-BEDA-7ED416AECC2A}"},
      new(){"Windows Firewall", "Microsoft.WindowsFirewall", "{4026492F-2F69-46B8-B9BF-5654FC07E423}"},
      new(){"Windows Mobility Center", "Microsoft.WindowsMobilityCenter", "{5F4F0761-9333-45AD-AA26-2B7CD220BFF6}"},
      new(){"Windows Update", "Microsoft.WindowsUpdate", "{36EEF7DB-88AD-4E81-AD49-0E313F0C35F8}"},
      new(){"Work Folders", "Microsoft.WorkFolders", "{ECDB0924-4208-451E-8EE0-373C0956DE16}" }
    };
  }

  class ControlPanelPageItem : ListItem {

    string canonicalName;

    public ControlPanelPageItem(string Title, string canonicalName, string GUID) {
      this.Name = Title;
      this.Description = $"{canonicalName} | {GUID}";
      this.canonicalName = canonicalName;
      this.Icon = new BitmapImage(new Uri(
          Environment.CurrentDirectory + "\\PlugBoard\\Plugin_Settings\\Plugin\\controlPanel.png"));
    }

    public override void Execute() {
      System.Diagnostics.Process.Start(Settings.cplPath, $"/name {canonicalName}");
      App.Current.MainWindow.Close();
    }
  }
}
