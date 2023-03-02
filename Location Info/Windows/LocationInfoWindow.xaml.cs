using Location_Info.Pages;
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
        Sport,
        Esport,
    }
    public partial class LocationInfoWindow : Window
    {

        private WeatherApiService _weatherApiService;
        private SportPage _sport => (_sportField ??= ServiceContainer.GetService<SportPage>());
        private WeatherPage _weather => (_weatherField ??= ServiceContainer.GetService<WeatherPage>());
        private EsportPage _esport => (_esportField ??= ServiceContainer.GetService<EsportPage>());
        private WeatherPage _weatherField;
        private SportPage _sportField;
        private EsportPage _esportField;
        private string _name { get; set; }
        
        public LocationInfoWindow()
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
            if(SportButton.IsEnabled) {CheckButtons(EButtons.Sport);  MainFrame.Content = _sport; }    
        } 
        private void EsportButton_Click(object sender, RoutedEventArgs e)
        {
            _name = EsportButton.Name;
            if(EsportButton.IsEnabled) {CheckButtons(EButtons.Esport);  MainFrame.Content = _esport; }    
        } 
        private void CheckButtons(EButtons button)
        {
            switch (button)
            {
                case EButtons.Weather:
                    WeatherButton.IsEnabled = false;
                    SportButton.IsEnabled = true;
                    EsportButton.IsEnabled = true;
                    break;
                case EButtons.Sport:
                    WeatherButton.IsEnabled = true;
                    SportButton.IsEnabled = false;
                    EsportButton.IsEnabled = true;
                    break;
                case EButtons.Esport:
                    WeatherButton.IsEnabled = true;
                    SportButton.IsEnabled = true;
                    EsportButton.IsEnabled = false;
                    break;

            }
        }
    }
}
