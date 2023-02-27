using MahApps.Metro.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using static Location_Info.Objects.ForecastObject;
using static Location_Info.Objects.WeatherObject;

namespace Location_Info.ViewModels
{
    internal class LocationInfoVM : ViewModel
    {

        private WeatherInfoVM weatherInfoVM;
        private ObservableCollection<ForecastDayVM> forecastDays;
        public RootWeather weather;
        public RootForecast forecast;
        private ChartVM chartVM;

        public WeatherInfoVM WeatherInfoVM { get { return weatherInfoVM; } set { weatherInfoVM = value; OnPropertyChanged(); } }
        public ObservableCollection<ForecastDayVM> ForecastDays { get { return forecastDays;  } set { forecastDays = value; OnPropertyChanged(); } }
        public ChartVM ChartVM { get { return chartVM; } set { chartVM = value; OnPropertyChanged(); } }

        public LocationInfoVM(string Name, string response ) {

            WeatherApiAsync(Name,response);
            ForecastApiAsync(Name);
            

        }
        private async void WeatherApiAsync(string Name, string response)
        {
            var rootweather = JsonConvert.DeserializeObject<RootWeather>(response);
            this.WeatherInfoVM = new WeatherInfoVM(rootweather);
        }

        private async void ForecastApiAsync(string Name)
        {
            HttpClient httpClient = new HttpClient();
            string ApiKey = "4dceb76fd9ea40bb873123657232302";
            string url = "http://api.weatherapi.com/v1/forecast.json?key=" + ApiKey + "&q=" + Name + "&days=3" + " & aqi=no" + "&alers=no";
            try
            {
                var response = await httpClient.GetStringAsync(url);
                var rootforecast = JsonConvert.DeserializeObject<RootForecast>(response);

                this.ForecastDays = new();
                foreach (var day in rootforecast.Forecast.Forecastday)
                {
                    forecastDays.Add(new ForecastDayVM(day));

                }
                this.ChartVM = new ChartVM(forecastDays);

            }
            catch (Exception ex)
            {
            }
        }
    }
}
