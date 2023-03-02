using Location_Info.Info;
using Location_Info.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static Location_Info.Objects.CountryCodeObject;
using static Location_Info.Objects.EsportObject;

namespace Location_Info.Services
{
    public class EsportApiService
    {
        private Database _database = ServiceContainer.GetService<Database>();
        private string _apiKey = "";

        public async Task<List<EsportInfo>> GetEsport(string Country)
        {
            _apiKey = _database.EsportApiKey; 
            string country = GetCountryCode(Country);
            HttpClient httpClient = new HttpClient();
            string url = "https://api.pandascore.co/teams?search[location]="+ country +"&sort=acronym&page=1&per_page=200&token="+ _apiKey;
            try
            {
                var response = await httpClient.GetStringAsync(url);

                var rootesport = JsonConvert.DeserializeObject<List<RootEsport>>(response);
                return rootesport.Select(x => new EsportInfo(x)).ToList();
            }
            catch (Exception ex)
            {
                return new List<EsportInfo>();
            }
        }
        public string GetCountryCode(string Country)
        {
            using (StreamReader r = new StreamReader("codes.json"))
            {
                string json = r.ReadToEnd();
                List<CountryCodeRoot> codes = JsonConvert.DeserializeObject<List<CountryCodeRoot>>(json);
                var code = codes.Find(x => x.Name == Country).Code;
                return code; 
            }
        }
    }
}
