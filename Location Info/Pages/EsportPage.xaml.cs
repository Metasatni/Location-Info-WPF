using Location_Info.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Location_Info.Pages
{
    /// <summary>
    /// Interaction logic for EsportPage.xaml
    /// </summary>
    public partial class EsportPage : Page
    {
        public EsportPage(EsportPageVM esportPageVM)
        {
            InitializeComponent();
            this.DataContext = esportPageVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
