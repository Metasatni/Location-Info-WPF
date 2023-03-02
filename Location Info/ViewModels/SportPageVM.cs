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
    public class SportPageVM : ViewModel
    {
        private ObservableCollection<Result> sportResults;
        private SportApiService _sportApiService;
        private Database _database => ServiceContainer.GetService<Database>();
        public RootSport rootSport;
        public ObservableCollection<Result> SportResults { get => sportResults; set {sportResults = value; OnPropertyChanged(); } }

        public SportPageVM(SportApiService sportApiService)
        {
            _sportApiService = sportApiService;
            RefreshData();

        }
        private async void RefreshData()
        {
            var sportResults = await _sportApiService.GetSport(_database.Country); 
            this.SportResults = new ObservableCollection<Result>(sportResults);
        }

    }
}
