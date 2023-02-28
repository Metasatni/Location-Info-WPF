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
    public partial class LocationInfo : Window
    {
        private Weather _weather { get; set; }
        public LocationInfo()
        {
            InitializeComponent();
        }

        public LocationInfo(string Name, string response)
        {
            InitializeComponent();
            var VM = new LocationInfoVM(Name, response);
            this.DataContext= VM;
            _weather = new Weather(Name, response);
            MainFrame.Content = _weather;
        }

        private void WeatherButton_Click(object sender, RoutedEventArgs e)
        {
            if(WeatherButton.IsEnabled) { CheckButtons(EButtons.Weather); MainFrame.Content = _weather; }   
        }
        private void SportButton_Click(object sender, RoutedEventArgs e)
        {
            if(SportButton.IsEnabled) {CheckButtons(EButtons.ESport); MainFrame.Content = new Sport(); }   
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
