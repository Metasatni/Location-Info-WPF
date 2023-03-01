using Location_Info.Services;
using Location_Info.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Location_Info
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;

        public App()
        {
            var ServiceCollection = new ServiceCollection();
            ServiceCollection.AddSingleton<MainWindow>();
            ServiceCollection.AddSingleton<MainWindowVM>();
            ServiceCollection.AddTransient<WeatherPage>();
            ServiceCollection.AddTransient<WeatherPageVM>();
            ServiceCollection.AddTransient<SportPage>();
            ServiceCollection.AddTransient<SportPageVM>();
            ServiceCollection.AddSingleton<Database>();
            ServiceCollection.AddSingleton<WeatherApiService>();
            ServiceCollection.AddSingleton<SportApiService>();
            
            _serviceProvider = ServiceCollection.BuildServiceProvider();
            ServiceContainer.Initailize(_serviceProvider);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var MainWindow = _serviceProvider.GetService<MainWindow>();
            MainWindow.Show();
            
        }
    }

}
