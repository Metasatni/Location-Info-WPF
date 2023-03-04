using Location_Info.Info;
using Location_Info.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Location_Info
{

    class Database
    {

        private List<EsportMatchesInfo> _esportMatchesInfo;
        private ObservableCollection<EsportInfo> _esportInfo;
        private ObservableCollection<PlayerInfo> _playerInfo;
        public string Name { get; set; }
        public string Country { get; set; }
        public string WeatherApiKey { get; set; }
        public string SportApiKey { get; set; }
        public string EsportApiKey { get; set; }
        public bool SportAutoRequest { get; set; }
        
        public ObservableCollection<PlayerInfo> PlayerInfo { get { return _playerInfo; } set { _playerInfo = value; DataChanged?.Invoke("PlayerInfo"); } }
        public ObservableCollection<EsportInfo> EsportInfo { get { return _esportInfo; } set { _esportInfo = value; DataChanged?.Invoke("EsportInfo"); } }
        public List<EsportMatchesInfo> EsportMatchesInfo { get { return  _esportMatchesInfo; } set { _esportMatchesInfo = value; DataChanged?.Invoke("EsportMatchesInfo") ; } }
        public event Action<string> DataChanged;

    }
}
