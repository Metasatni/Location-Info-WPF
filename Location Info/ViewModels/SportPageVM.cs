using Location_Info.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static Location_Info.Objects.SportObject;

namespace Location_Info.ViewModels
{
    class SportPageVM : ViewModel
    {
        private string _country;
        private ObservableCollection<Result> sportResults;
        private SportApiService _sportApiService;
        public RootSport rootSport;
        public ObservableCollection<Result> SportResults { get => sportResults; set {sportResults = value; OnPropertyChanged(); } }

        public SportPageVM(string Country)
        {
            _sportApiService = new SportApiService();
            this._country = Country;
            _ = _sportApiService.GetSport(Country);

        }

       
    }

}
