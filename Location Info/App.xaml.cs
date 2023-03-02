using Location_Info.ConfigManager;
using Location_Info.Pages;
using Location_Info.Services;
using Location_Info.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Location_Info
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        private Database _database => ServiceContainer.GetService<Database>();
        public App()
        {

            var config = new CFGManager("Config.ini");

            var ServiceCollection = new ServiceCollection();
            ServiceCollection.AddSingleton<MainWindow>();
            ServiceCollection.AddTransient<WeatherPage>();
            ServiceCollection.AddTransient<SportPage>();
            ServiceCollection.AddTransient<EsportPage>();
            ServiceCollection.AddTransient<EsportPageVM>();
            ServiceCollection.AddTransient<SportPageVM>();
            ServiceCollection.AddTransient<WeatherPageVM>();
            ServiceCollection.AddSingleton<MainWindowVM>();
            ServiceCollection.AddSingleton<Database>();
            ServiceCollection.AddSingleton<WeatherApiService>();
            ServiceCollection.AddSingleton<SportApiService>();
            ServiceCollection.AddSingleton<EsportApiService>();
            
            _serviceProvider = ServiceCollection.BuildServiceProvider();
            ServiceContainer.Initailize(_serviceProvider);

            _database.WeatherApiKey = config.Read("WeatherApiKey");
            _database.SportApiKey = config.Read("SportApiKey");
            _database.EsportApiKey = config.Read("EsportApiKey");
            _database.SportAutoRequest = Convert.ToBoolean(config.Read("SportAutoRequest"));
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var MainWindow = _serviceProvider.GetService<MainWindow>();
            MainWindow.Show();
            
        }
    }

}
