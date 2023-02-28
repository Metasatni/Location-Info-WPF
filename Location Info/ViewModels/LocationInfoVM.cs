using Location_Info.Buttons;
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

        private WeatherButton weatherButton;
        private SportButton sportButton;

        public WeatherButton WeatherButton { get { return weatherButton; } set { weatherButton = value; OnPropertyChanged(); } }
        public SportButton SportButton { get { return sportButton; } set { sportButton = value; OnPropertyChanged(); } }
   
        public LocationInfoVM(string Name, string response ) {

            WeatherButton = new WeatherButton();
            SportButton = new SportButton();
            Weather weather = new Weather(Name, response);
            

        }
    }
}
