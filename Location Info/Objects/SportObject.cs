using Newtonsoft.Json;
using System.Collections.Generic;

namespace Location_Info.Objects
{
    public class SportObject
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Category
        {
            [JsonProperty("alpha2")]
            public string Alpha2 { get; set; }

            [JsonProperty("flag")]
            public string Flag { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("sport")]
            public Sport Sport { get; set; }
        }

        public class Country
        {
            [JsonProperty("alpha2")]
            public string Alpha2 { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class Entity
        {
            [JsonProperty("category")]
            public Category Category { get; set; }

            [JsonProperty("country")]
            public Country Country { get; set; }

            [JsonProperty("disabled")]
            public bool? Disabled { get; set; }

            [JsonProperty("displayInverseHomeAwayTeams")]
            public bool? DisplayInverseHomeAwayTeams { get; set; }

            [JsonProperty("firstName")]
            public object FirstName { get; set; }

            [JsonProperty("gender")]
            public string Gender { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("lastName")]
            public object LastName { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("nameCode")]
            public string NameCode { get; set; }

            [JsonProperty("national")]
            public bool? National { get; set; }

            [JsonProperty("position")]
            public object Position { get; set; }

            [JsonProperty("ranking")]
            public int? Ranking { get; set; }

            [JsonProperty("shortName")]
            public string ShortName { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("sport")]
            public Sport Sport { get; set; }

            [JsonProperty("team")]
            public object Team { get; set; }

            [JsonProperty("teamColors")]
            public TeamColors TeamColors { get; set; }

            [JsonProperty("type")]
            public int? Type { get; set; }

            [JsonProperty("userCount")]
            public int UserCount { get; set; }
        }

        public class Result
        {
            [JsonProperty("entity")]
            public Entity Entity { get; set; }

            [JsonProperty("score")]
            public double Score { get; set; }

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
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }
        }

        public class TeamColors
        {
            [JsonProperty("primary")]
            public string Primary { get; set; }

            [JsonProperty("secondary")]
            public string Secondary { get; set; }

            [JsonProperty("text")]
            public string Text { get; set; }
        }


    }
}
