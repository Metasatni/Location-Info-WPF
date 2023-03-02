﻿using Location_Info.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Location_Info
{

    class Database
    {

        public string Name { get; set; }
        public string Country { get; set; }
        public string WeatherApiKey { get; set; }
        public string SportApiKey { get; set; }
        public string EsportApiKey { get; set; }
        public bool SportAutoRequest { get; set; }

    }
}
