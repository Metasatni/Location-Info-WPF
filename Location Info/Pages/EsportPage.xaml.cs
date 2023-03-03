using Location_Info.Info;
using Location_Info.ViewModels;
using Location_Info.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Location_Info.Pages
{
    /// <summary>
    /// Interaction logic for EsportPage.xaml
    /// </summary>
    public partial class EsportPage : Page
    {
        private Database _database => ServiceContainer.GetService<Database>();
        private ObservableCollection<EsportInfo> _esportInfo;
        private EsportPageVM _esportPageVM;
        public EsportPage(EsportPageVM esportPageVM)
        {
            InitializeComponent();
            _esportPageVM = esportPageVM;
            this.DataContext = _esportPageVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            EsportInfo esportInfoBT = button?.DataContext as EsportInfo;
            string name = esportInfoBT.Name;
            string gamename = esportInfoBT.GameName;
            ImageSource icon = esportInfoBT.Ico;
            var esportInfo = _database.EsportInfo;
            var esportInfoFiltered = esportInfo.Where(info => info.Name == name && info.GameName == gamename).FirstOrDefault();
            ObservableCollection<PlayerInfo> players = new ObservableCollection<PlayerInfo>(esportInfoFiltered.Players);

            //var esportInfoFiltered = esportInfo.Where(info => info.Name == name && info.GameName == gamename).FirstOrDefault();
            //ObservableCollection<PlayerInfo> players = new ObservableCollection<PlayerInfo>(esportInfoFiltered); 



            var playersWindow = new PlayersWindow();
            playersWindow.DataContext = new PlayersWindowVM(esportInfo, players, name, icon);
            playersWindow.Show();
        }

        private void IsLiveButton_Click(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            EsportInfo esportInfoBT = button?.DataContext as EsportInfo;
            string url = esportInfoBT.Stream;
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
    }
}
