using static Location_Info.Objects.SportObject;

namespace Location_Info.ViewModels
{
    internal class SportInfo
    {
        public string Name { get; set; }
        public string SportName { get; set; }
        public string Type { get; set; }
        
        public SportInfo(RootSport sport)
        {
            var entity = sport.Results[0].Entity;
            var type = sport.Results[2].Type;

            this.Name = entity.Name;
            this.SportName = entity.Team.Sport.Name;
            this.Type = type;
        }
    }
}
