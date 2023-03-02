using Location_Info.Info;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Location_Info.ViewModels
{
    public class PlayersWindowVM : ViewModel
    {
        private ObservableCollection<PlayerInfo> _players;
        private ObservableCollection<EsportInfo> _esportInfo;
        private string _name;
        private ImageSource _icon;
        public ImageSource Icon { get { return _icon; } set { _icon = value; OnPropertyChanged(); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }
        public ObservableCollection<PlayerInfo> Players { get { return _players; } set { _players = value; OnPropertyChanged(); } }
        public ObservableCollection<EsportInfo> EsportInfo { get { return _esportInfo; } set { _esportInfo = value; OnPropertyChanged(); } }

        public PlayersWindowVM(ObservableCollection<EsportInfo> esportInfo ,ObservableCollection<PlayerInfo> players, string name, ImageSource icon)
        {
            this.Players = players;
            this.EsportInfo = esportInfo;
            this.Name = name;
            this.Icon = icon;
        }
    }

}
