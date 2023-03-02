using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Location_Info.Objects.EsportObject;

namespace Location_Info.Info
{
    public class PlayerInfo
    {
        public string Name {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PlayerInfo(Player Player) {

            this.Name = Player.Name;
            this.FirstName = Player.FirstName;
            this.LastName = Player.LastName;

        }
    }
}
