using Quokka;
using Quokka.ListItems;
using System.Windows.Media.Imaging;

namespace Plugin_Settings {
  class TypedTextItem2 : ListItem {

    public TypedTextItem2(string query) {
      this.Name = "Typed:" + query;
      this.Description = "The search field contains the above text";
      this.Icon = new BitmapImage(new Uri(
          Environment.CurrentDirectory + "\\PlugBoard\\Plugin_Settings\\Plugin\\controlPanel.png"));
    }

    public override void Execute() {
      // launch page
      App.Current.MainWindow.Close();
    }
  }
}
