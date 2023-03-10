using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Location_Info.Objects.ForecastObject;

namespace Location_Info.ViewModels
{
    public class HourInfo
    {
        public string Hour {  get; set; }
        public double TempC { get; set; }
        public double WindKPH { get; set; }
        public double FeelsLikeC { get; set; }
        public double Snowing { get; set; }
        public double Raining { get; set; }

        public HourInfo(Hour Hour) {
            this.Hour = Hour.Time.Split(' ')[1];
            this.TempC = Hour.TempC;
            this.WindKPH = Hour.WindKph;
            this.FeelsLikeC = Hour.FeelslikeC;
            this.Snowing = Hour.ChanceOfSnow;
            this.Raining = Hour.ChanceOfRain;
        }

    }
}
