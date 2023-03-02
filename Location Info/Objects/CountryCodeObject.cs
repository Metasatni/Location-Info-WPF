using Newtonsoft.Json;

namespace Location_Info.Objects
{
    class CountryCodeObject
    {
        public class CountryCodeRoot
        {
            [JsonProperty("Code")]
            public string Code { get; set; }

            [JsonProperty("Name")]
            public string Name { get; set; }
        }


    }
}
