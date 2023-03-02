using Location_Info.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static Location_Info.Objects.ForecastObject;
using static Location_Info.Objects.WeatherObject;

namespace Location_Info.Services
{
    public class WeatherApiService
    {
        private Database _database => ServiceContainer.GetService<Database>();
        private string _apiKey ="";
        public async Task<List<ForecastInfo>> GetForecast(string Name)
        {
            _apiKey = _database.WeatherApiKey; 
            HttpClient httpClient = new HttpClient();
            string url = "http://api.weatherapi.com/v1/forecast.json?key=" + _apiKey + "&q=" + Name + "&days=3" + " & aqi=no" + "&alers=no";
            try
            {
                var response = await httpClient.GetStringAsync(url);
                var rootforecast = JsonConvert.DeserializeObject<RootForecast>(response);
                var forecastDays = new List<ForecastInfo>();
                foreach (var day in rootforecast.Forecast.Forecastday)
                {
                    forecastDays.Add(new ForecastInfo(day));
                }
                return forecastDays;
            }
            catch (Exception ex)
            {
                return new List<ForecastInfo>();
            }
        }
        public async Task <WeatherInfo> GetWeather(string Name)
        {
            HttpClient httpClient = new HttpClient();
            _apiKey = _database.WeatherApiKey;
            string url = "http://api.weatherapi.com/v1/current.json?key=" + _apiKey + "&q=" + Name + "&aqi=no";
            try
            {
                var response = await httpClient.GetStringAsync(url);
                var weather = JsonConvert.DeserializeObject<RootWeather>(response);
                return new WeatherInfo(weather);

            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}
