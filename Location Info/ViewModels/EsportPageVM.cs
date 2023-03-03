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
            RefreshData();
        }

        private async void RefreshData()
        {
            var esportMatchesInfo = await _esportApiService.GetEsportCurrentMatches();
            this.EsportMatchesInfo = esportMatchesInfo;
            var esportInfo = await _esportApiService.GetEsportTeams(_database.Country);
            this.EsportInfo = new ObservableCollection<EsportInfo>(esportInfo.OrderByDescending(x => x.Updated));
            foreach (var matches in EsportMatchesInfo)
            {
                foreach (var team in EsportInfo)
                {
                    if (team.Slug == matches.Slug)
                    {
                        team.Stream = matches.StreamUrl[0].StreamUrl;
                        team.IsLive = "Visible";
                    }
                }
            }
            var players = this.EsportInfo.SelectMany(info => info.Players);
            this.PlayerInfo = new ObservableCollection<PlayerInfo>(players);
            _database.EsportInfo = this.EsportInfo;
        }
    }
}
