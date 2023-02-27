using System.Windows;
using static Location_Info.Objects.WeatherObject;

namespace Location_Info.ViewModels
{
    /// <summary>
    /// Interaction logic for LocationInfo.xaml
    /// </summary>
    public partial class LocationInfo : Window
    {
        public LocationInfo()
        {
            InitializeComponent();
        }

        public LocationInfo(string name, string response)
        {
            InitializeComponent();
            var VM = new LocationInfoVM(name, response);
            this.DataContext= VM;
        }
    }
}
