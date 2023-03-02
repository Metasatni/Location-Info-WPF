using Location_Info.Buttons;

namespace Location_Info.ViewModels
{
    internal class LocationInfoWindowVM : ViewModel
    {


        private WeatherButton weatherButton;
        private SportButton sportButton;

        public Database Database => ServiceContainer.GetService<Database>();
        public WeatherButton WeatherButton { get { return weatherButton; } set { weatherButton = value; OnPropertyChanged(); } }
        public SportButton SportButton { get { return sportButton; } set { sportButton = value; OnPropertyChanged(); } }
   
        public LocationInfoWindowVM() {

            WeatherButton = new WeatherButton();
            SportButton = new SportButton();

            WeatherPage weather = ServiceContainer.GetService<WeatherPage>();            

        }
    }
}
