using Location_Info.Services;
using System.Windows.Controls;

namespace Location_Info.ViewModels
{
    /// <summary>
    /// Interaction logic for Weather.xaml
    /// </summary>
    public partial class WeatherPage : Page
    {
        public WeatherPage(WeatherPageVM weatherPageVM)
        {
            InitializeComponent();
            this.DataContext = weatherPageVM;
        }
    }
}
