using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Location_Info.Objects
{
    public class EsportObject
    {
        public class CurrentVideogame
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }
        }

        public class Player
        {
            [JsonProperty("age")]
            public int? Age { get; set; }

            [JsonProperty("birthday")]
            public string Birthday { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("image_url")]
            public string ImageUrl { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("modified_at")]
            public DateTime ModifiedAt { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nationality")]
            public string Nationality { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }
        }

        public class RootEsport
        {
            [JsonProperty("acronym")]
            public string Acronym { get; set; }

            [JsonProperty("current_videogame")]
            public CurrentVideogame CurrentVideogame { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("image_url")]
            public string ImageUrl { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("modified_at")]
            public DateTime ModifiedAt { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("players")]
            public List<Player> Players { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }
        }

    }
}
