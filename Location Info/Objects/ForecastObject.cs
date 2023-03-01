using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_Info.Objects
{
    public class ForecastObject
    {
        public class Astro
        {
            [JsonProperty("sunrise")]
            public string Sunrise { get; set; }

            [JsonProperty("sunset")]
            public string Sunset { get; set; }

            [JsonProperty("moonrise")]
            public string Moonrise { get; set; }

        }
        public class Day
        {
          
            [JsonProperty("avgtemp_c")]
            public double AvgtempC { get; set; }
        
            [JsonProperty("maxwind_kph")]
            public double MaxwindKph { get; set; }

        }

        public class Forecast
        {

            [JsonProperty("forecastday")]
            public List<Forecastday> Forecastday { get; set; }

        }

        public class Forecastday
        {

            [JsonProperty("date")]
            public string Date { get; set; }
       
            [JsonProperty("day")]
            public Day Day { get; set; }

            [JsonProperty("astro")]
            public Astro Astro { get; set; }

            [JsonProperty("hour")]
            public List<Hour> Hour { get; set; }
        }

        public class Hour
        {
  
            [JsonProperty("time")]
            public string Time { get; set; }

            [JsonProperty("temp_c")]
            public double TempC { get; set; }

            [JsonProperty("wind_kph")]
            public double WindKph { get; set; }

            [JsonProperty("feelslike_c")]
            public double FeelslikeC { get; set; }

            [JsonProperty("chance_of_rain")]
            public int ChanceOfRain { get; set; }
       
            [JsonProperty("chance_of_snow")]
            public int ChanceOfSnow { get; set; }

        }

        public class RootForecast
        {

            [JsonProperty("forecast")]
            public Forecast Forecast { get; set; }

        }
    }
}
