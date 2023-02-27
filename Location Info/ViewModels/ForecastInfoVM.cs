using System.Collections.Generic;
using System.Linq;
using static Location_Info.Objects.ForecastObject;

namespace Location_Info.ViewModels
{
    internal class ForecastDayVM
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string Moonrise { get; set; }
        public double Temp_c { get; set; }
        public double Wind_kph { get; set; }
        public string Date { get; set; }

        public List<HourVM> Hours { get; set; }

        public ForecastDayVM(Forecastday day)
        {
            this.Sunrise = day.Astro.Sunrise;
            this.Sunset = day.Astro.Sunset;
            this.Moonrise = day.Astro.Moonrise;
            this.Temp_c = day.Day.AvgtempC;
            this.Wind_kph = day.Day.MaxwindKph;
            this.Date = day.Date;
            this.Hours = day.Hour.Select(x => new HourVM(x)).ToList();

        }

}
}
