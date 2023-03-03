using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static Location_Info.Objects.EsportMatchesObject;
using static Location_Info.Objects.EsportObject;

namespace Location_Info.Info
{
    public class EsportMatchesInfo
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public List<StreamInfo> StreamUrl { get; set; }
        public EsportMatchesInfo(EsportMatchesRoot rootEsportMatches)
        {

            var converter = new ImageSourceConverter();
            this.Name = rootEsportMatches.Name;
            this.Slug = rootEsportMatches.Opponents[0].Opponents.Slug;
            this.StreamUrl = rootEsportMatches.StreamsList.Select(x => new StreamInfo(x)).ToList();
                      
        }

    }
}
