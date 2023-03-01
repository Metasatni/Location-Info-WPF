using Location_Info.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Location_Info
{

    class Database
    {

        public string Name { get; set; }
        public string Country { get; set; }
        public WeatherInfo WeatherInfo { get; set; }
        public ForecastInfo ForecastInfo { get; set; }

    }
}
