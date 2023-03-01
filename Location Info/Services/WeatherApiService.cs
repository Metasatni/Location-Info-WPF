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
        private string ApiKey = "4dceb76fd9ea40bb873123657232302";
        public async Task<List<ForecastInfo>> GetForecast(string Name)
        {
            HttpClient httpClient = new HttpClient();
            string url = "http://api.weatherapi.com/v1/forecast.json?key=" + ApiKey + "&q=" + Name + "&days=3" + " & aqi=no" + "&alers=no";
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
            string url = "http://api.weatherapi.com/v1/current.json?key=" + ApiKey + "&q=" + Name + "&aqi=no";
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
