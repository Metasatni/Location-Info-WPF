using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.ObjectModel;

namespace Location_Info.ViewModels
{
    class ChartVM : ViewModel
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public ChartVM(ObservableCollection<ForecastDayVM> ForecastDays)
        {
                double[][] temperatures = new double[7][];

                for (var i = 0; i < ForecastDays.Count; i++)
                {
                    temperatures[i] = new double[24];
                    for (var j = 0; j < ForecastDays[i].Hours.Count; j++)
                    {
                        temperatures[i][j] = ForecastDays[i].Hours[j].TempC;
                    }
                }

                SeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    { Title = ForecastDays[0].Date, Values = new ChartValues < double >(temperatures[0]) },
                    new LineSeries
                    { Title = ForecastDays[1].Date, Values = new ChartValues < double >(temperatures[1]) },
                    new LineSeries
                    { Title = ForecastDays[2].Date, Values = new ChartValues < double >(temperatures[2]) }
                };

                Labels = new[] {
                    "12 PM","01 AM","02 AM","03 AM","04 AM","05 AM","06 AM","07 AM","08 AM","09 AM","10 AM","11 AM","12 AM"
                    ,"01 PM","02 PM","03 PM","04 PM","05 PM","06 PM","07 PM","08 PM","09 PM","10 PM","11 PM",};
                YFormatter = value => value.ToString();
                OnPropertyChanged(nameof(SeriesCollection));

        }
    }
}
