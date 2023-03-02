using Location_Info.Info;
using Location_Info.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Location_Info.ViewModels
{
    public class EsportPageVM : ViewModel
    {
        private Database _database = ServiceContainer.GetService<Database>();
        private EsportApiService _esportApiService;
        private ObservableCollection<EsportInfo> _esportInfo;
        private ObservableCollection<PlayerInfo> _playerInfo;
        public ObservableCollection<EsportInfo> EsportInfo { get { return _esportInfo; } set { _esportInfo = value; OnPropertyChanged(); } }
        public ObservableCollection<PlayerInfo> PlayerInfo { get { return _playerInfo; } set { _playerInfo = value; OnPropertyChanged(); } }
        public ICommand ViewPlayersCommand { get; }

        public EsportPageVM(EsportApiService esportApiService)
        {
            _esportApiService = esportApiService;
            RefreshData();
        }

        private async void RefreshData()
        {
            var esportInfo = await _esportApiService.GetEsport(_database.Country);
            this.EsportInfo = new ObservableCollection<EsportInfo>(esportInfo);
            var players = this.EsportInfo.SelectMany(info => info.Players);
            this.PlayerInfo = new ObservableCollection<PlayerInfo>(players);
            _database.EsportInfo = this.EsportInfo;
        }

    }
}
