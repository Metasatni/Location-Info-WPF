using Location_Info.Info;
using Location_Info.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Location_Info.ViewModels
{
    public class WeatherPageVM : ViewModel
    {
        private Database _database => ServiceContainer.GetService<Database>();
        private WeatherInfo weatherInfo;
        private ObservableCollection<ForecastInfo> forecastDays;
        private ChartInfo chartVM;
        private WeatherApiService _weatherApiService;
        private EsportApiService _esportApiService;
        private List<EsportMatchesInfo> _esportMatchesInfo;
        private ObservableCollection<EsportInfo>  _esportInfo;
        private ObservableCollection<PlayerInfo> _playerInfo;
        public List<EsportMatchesInfo> EsportMatchesInfo { get { return _esportMatchesInfo; } set { _esportMatchesInfo = value; OnPropertyChanged(); } }
        public ObservableCollection<PlayerInfo> PlayerInfo { get { return _playerInfo; } set { _playerInfo = value; OnPropertyChanged(); } }
        public ObservableCollection<EsportInfo> EsportInfo { get { return _esportInfo; } set { _esportInfo = value; OnPropertyChanged(); } }
        public WeatherInfo WeatherInfo { get { return weatherInfo; } set { weatherInfo = value; OnPropertyChanged(); } }
        public ObservableCollection<ForecastInfo> ForecastDays { get { return forecastDays;  } set { forecastDays = value; OnPropertyChanged(); } }
        public ChartInfo ChartInfo { get { return chartVM; } set { chartVM = value; OnPropertyChanged(); } }

        public WeatherPageVM(WeatherApiService weatherApiService, EsportApiService esportApiService)
        {
            _weatherApiService = weatherApiService;
            _esportApiService = esportApiService;
            RefreshData(); 
            
        }
        private async void RefreshData()
        {
            this.WeatherInfo = await _weatherApiService.GetWeather(_database.Name);
            var forecastdays = await _weatherApiService.GetForecast(_database.Name);
            this.ForecastDays = new ObservableCollection<ForecastInfo>(forecastdays);
            ChartInfo = new ChartInfo(ForecastDays);
            _database.Country = this.WeatherInfo.Country;
            var esportMatchesInfo = await _esportApiService.GetEsportCurrentMatches();
            this.EsportMatchesInfo = esportMatchesInfo; 
            _database.EsportMatchesInfo = esportMatchesInfo;
            var esportInfo = await _esportApiService.GetEsportTeams(_database.Country);
            this.EsportInfo = new ObservableCollection<EsportInfo>(esportInfo.OrderByDescending(x => x.Updated));
            _database.EsportInfo = new ObservableCollection<EsportInfo>(esportInfo.OrderByDescending(x => x.Updated));
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
            _database.PlayerInfo = new ObservableCollection<PlayerInfo>(players);
            _database.EsportInfo = this.EsportInfo;
        }
    }
}
