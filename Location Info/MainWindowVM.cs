using Location_Info.Objects;
using Location_Info.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static Location_Info.Objects.WeatherObject;

namespace Location_Info
{
    internal class MainWindowVM : ViewModel
    {

        private string _name;

        public MainWindowVM()
        {
            string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
            Name = externalIpString;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public ICommand SearchCommand { get => new Command(SearchHandler); }

        public void SearchHandler(object? obj)
        {
            if(Name == null) { return; }
            if(Name.Length <= 1) { return; }
            WeatherApiAsync(Name);
        }
        private async void WeatherApiAsync(string Name)
        {
            HttpClient httpClient = new HttpClient();
            string ApiKey = "4dceb76fd9ea40bb873123657232302";
            string url = "http://api.weatherapi.com/v1/current.json?key=" + ApiKey + "&q=" + Name + "&aqi=no";
            try
            {
                var response = await httpClient.GetStringAsync(url);
                LocationInfo locationInfo = new LocationInfo(Name,response);
                locationInfo.Show();
            }catch (Exception ex)
            {
                
            }
        }
    }
}
