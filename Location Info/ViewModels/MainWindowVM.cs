using Location_Info.Services;
using Location_Info.ViewModels;
using System.Net;
using System.Windows.Input;

namespace Location_Info
{
    public class MainWindowVM : ViewModel
    {
        
        private string _name;
        Database Database => ServiceContainer.GetService<Database>();
        private WeatherApiService _weatherApiService;
        public MainWindowVM()
        {
            string externalIpString = new WebClient().DownloadString("http://icanhazip.com").Replace("\\r\\n", "").Replace("\\n", "").Trim();
            Name = externalIpString;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public ICommand SearchCommand { get => new Command(SearchHandler); }

        public async void SearchHandler(object? obj)
        {
            if(Name == null) { return; }
            if(Name.Length <= 1) { return; }
            _weatherApiService = new WeatherApiService();
            Database.Name = Name;
            var response = _weatherApiService.GetWeather(Name);
            if(response != null) { LocationInfoPage locationInfoPage = new LocationInfoPage(); locationInfoPage.Show(); }
        }
    }
}
