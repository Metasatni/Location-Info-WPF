using Location_Info.Buttons;
using Location_Info.Services;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using static Location_Info.Objects.ForecastObject;
using static Location_Info.Objects.WeatherObject;

namespace Location_Info.ViewModels
{
    public class WeatherPageVM : ViewModel
    {
        private Database Database => ServiceContainer.GetService<Database>();
        private WeatherInfo weatherInfo;
        private ObservableCollection<ForecastInfo> forecastDays;
        private ChartInfo chartVM;
        private WeatherApiService _weatherApiService;
        public WeatherInfo WeatherInfo { get { return weatherInfo; } set { weatherInfo = value; OnPropertyChanged(); } }
        public ObservableCollection<ForecastInfo> ForecastDays { get { return forecastDays;  } set { forecastDays = value; OnPropertyChanged(); } }
        public ChartInfo ChartInfo { get { return chartVM; } set { chartVM = value; OnPropertyChanged(); } }

        public WeatherPageVM(WeatherApiService weatherApiService)
        {
            _weatherApiService = weatherApiService;
            RefreshData(); 
        }
        private async void RefreshData()
        {
            this.WeatherInfo = await _weatherApiService.GetWeather(Database.Name);
            var forecastdays = await _weatherApiService.GetForecast(Database.Name);
            this.ForecastDays = new ObservableCollection<ForecastInfo>(forecastdays);
            ChartInfo = new ChartInfo(ForecastDays);

        }
    }
}
