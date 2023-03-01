using Location_Info.Services;
using System.Windows;

namespace Location_Info.ViewModels
{
    /// <summary>
    /// Interaction logic for LocationInfo.xaml
    /// </summary>
    ///
    public enum EButtons
    {
        Weather,
        ESport,
    }
    public partial class LocationInfoPage : Window
    {

        private WeatherApiService _weatherApiService;
        private Database Database => ServiceContainer.GetService<Database>();
        private SportPage _sport => (_sportField ??= ServiceContainer.GetService<SportPage>());
        private WeatherPage _weather => (_weatherField ??= ServiceContainer.GetService<WeatherPage>());
        private WeatherPage _weatherField;
        private SportPage _sportField;
        private string _name { get; set; }
        
        public LocationInfoPage()
        {
            InitializeComponent();
            MainFrame.Content = _weather;

        }

        private void WeatherButton_Click(object sender, RoutedEventArgs e)
        {
            if(WeatherButton.IsEnabled) { CheckButtons(EButtons.Weather); MainFrame.Content = _weather; }   
        }
        private void SportButton_Click(object sender, RoutedEventArgs e)
        {
            _name = SportButton.Name;
            if(SportButton.IsEnabled) {CheckButtons(EButtons.ESport);  MainFrame.Content = _sport; }    
        } 
        private void CheckButtons(EButtons button)
        {
            switch (button)
            {
                case EButtons.Weather:
                    WeatherButton.IsEnabled = false;
                    SportButton.IsEnabled = true;
                    break;
                case EButtons.ESport:
                    WeatherButton.IsEnabled = true;
                    SportButton.IsEnabled = false;
                    break;

            }
        }
    }
}
