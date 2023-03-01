using Newtonsoft.Json;
using System.Collections.Generic;

namespace Location_Info.Objects
{
    class SportObject
    {
       public class Entity
        {
        
            [JsonProperty("name")]
            public string Name { get; set; }

       
            [JsonProperty("team")]
            public Team Team { get; set; }
        }

        public class Result
        {
            [JsonProperty("entity")]
            public Entity Entity { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public class RootSport
        {
            [JsonProperty("results")]
            public List<Result> Results { get; set; }
        }

        public class Sport
        {
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class Team
        {
            [JsonProperty("sport")]
            public Sport Sport { get; set; }

        }
    }
}
