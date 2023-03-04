using Location_Info.Info;
using Location_Info.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Location_Info.ViewModels
{
    public class EsportPageVM : ViewModel
    {
        private Database _database = ServiceContainer.GetService<Database>();
        private EsportApiService _esportApiService;
        private ObservableCollection<EsportInfo> _esportInfo;
        private ObservableCollection<PlayerInfo> _playerInfo;
        private List<EsportMatchesInfo> _esportMatchesInfo;
        public List<EsportMatchesInfo> EsportMatchesInfo { get { return _esportMatchesInfo; } set { _esportMatchesInfo = value; OnPropertyChanged(); } }
        public ObservableCollection<EsportInfo> EsportInfo { get { return _esportInfo; } set { _esportInfo = value; OnPropertyChanged(); } }
        public ObservableCollection<PlayerInfo> PlayerInfo { get { return _playerInfo; } set { _playerInfo = value; OnPropertyChanged(); } }
        public ICommand ViewPlayersCommand { get; }

        public EsportPageVM(EsportApiService esportApiService)
        {
            _esportApiService = esportApiService;
            RefreshData("All");
            _database.DataChanged += RefreshData;
        }

        private async void RefreshData(string datatype)
        {
            switch (datatype)
            {
                case "All":
                    this.PlayerInfo = _database.PlayerInfo;
                    this.EsportInfo = _database.EsportInfo;
                    this.EsportMatchesInfo = _database.EsportMatchesInfo;
                    break;
                case "EsportMatchesInfo":
                    this.EsportMatchesInfo = _database.EsportMatchesInfo;
                    break;
                case "EsportInfo":
                    this.EsportInfo = _database.EsportInfo;
                    break;
                case "PlayerInfo":
                    this.PlayerInfo = _database.PlayerInfo;
                    break;

            }

        }

    }
}
