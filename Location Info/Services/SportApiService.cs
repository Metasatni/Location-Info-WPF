using Location_Info.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Documents;
using static Location_Info.Objects.SportObject;

namespace Location_Info.Services
{
    class SportApiService
    {
        public async Task<List<Result>> GetSport(string Country)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://footapi7.p.rapidapi.com/api/search/" + Country),
                Headers =
                    {
                        { "X-RapidAPI-Key", "de8248b955mshf55ad42ee395bd3p1a2fdbjsnaf254dd0c985" },
                        { "X-RapidAPI-Host", "footapi7.p.rapidapi.com" },
                    },
            };
            try
            {
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var stringresponse = await response.Content.ReadAsStringAsync();
                    var rootSport = JsonConvert.DeserializeObject<RootSport>(stringresponse);

                    var SportResults = new List<Result>();

                    foreach (var result in rootSport.Results)
                    {
                        SportResults.Add(result);
                    }

                    return SportResults;

                }
            }
            catch (Exception ex)
            {
                return new List<Result>();
            }
        }
    }
}
