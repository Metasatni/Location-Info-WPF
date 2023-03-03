using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using static Location_Info.Objects.EsportObject;

namespace Location_Info.Info
{
    public class EsportInfo
    {
        public string Name { get; set; }
        public string GameName {  get; set; }
        public string Slug { get; set; }
        public DateTime Updated { get; set; }
        public ImageSource Ico { get; set; }
        public bool IsLive { get; set; }
        public List<PlayerInfo> Players { get; set; }
        public EsportInfo(RootEsport rootEsport)
        {

            var converter = new ImageSourceConverter();
            this.Name = rootEsport.Name;
            this.Slug = rootEsport.Slug;
            this.GameName = rootEsport.CurrentVideogame.Name;
            this.Players = rootEsport.Players.Select(x => new PlayerInfo(x)).ToList();
            this.Updated = rootEsport.ModifiedAt;
            if(rootEsport.ImageUrl != null)
            {
                this.Ico = (converter.ConvertFromString(rootEsport.ImageUrl) as ImageSource);
            }
            
        }
    }
}
