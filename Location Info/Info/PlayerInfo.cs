using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static Location_Info.Objects.EsportObject;

namespace Location_Info.Info
{
    public class PlayerInfo
    {
        public string Name {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public DateTime Updated { get; set; }
        public ImageSource Ico { get; set; }

        public PlayerInfo(Player Player) {
            var converter = new ImageSourceConverter();
            this.Name = Player.Name;
            this.FirstName = Player.FirstName;
            this.LastName = Player.LastName;
            this.Nationality = Player.Nationality;
            this.Updated = Player.ModifiedAt;
            if(Player.ImageUrl != null)
            {
                this.Ico = (converter.ConvertFromString(Player.ImageUrl) as ImageSource);
            }

        }
    }
}
