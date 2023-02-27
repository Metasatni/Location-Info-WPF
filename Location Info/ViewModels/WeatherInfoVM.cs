using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Location_Info.Objects.WeatherObject;

namespace Location_Info.ViewModels
{
    internal class WeatherInfoVM
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Condition { get; set; }
        public double Temperature { get; set; }
        public double Wind { get; set; }
        public double Pressure { get; set; }

        public WeatherInfoVM(RootWeather weather)
        {
            this.Name = weather.Location.Name;
            this.Country = weather.Location.Country;
            this.Condition = weather.Current.Condition.Text;
            this.Temperature = weather.Current.TempC;
            this.Wind = weather.Current.WindKph;
            this.Pressure = weather.Current.PressureMb;
        }
    }
}
