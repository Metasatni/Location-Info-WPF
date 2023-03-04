using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.ObjectModel;

namespace Location_Info.ViewModels
{
    public class ChartInfo
    {
        public SeriesCollection TemperatureCollection { get; set; }
        public SeriesCollection SnowingChancesCollection { get; set; }
        public SeriesCollection RainingChancesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public ChartInfo(ObservableCollection<ForecastInfo> ForecastDays)
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

                double[][] snowing = new double[7][];

                for (var i = 0; i < ForecastDays.Count; i++)
                {
                    snowing[i] = new double[24];
                    for (var j = 0; j < ForecastDays[i].Hours.Count; j++)
                    {
                        snowing[i][j] = ForecastDays[i].Hours[j].Snowing;
                    }
                }

                double[][] raining = new double[7][];

                for (var i = 0; i < ForecastDays.Count; i++)
                {
                    raining[i] = new double[24];
                    for (var j = 0; j < ForecastDays[i].Hours.Count; j++)
                    {
                        raining[i][j] = ForecastDays[i].Hours[j].Raining;
                    }
                }

                if(temperatures[0] != null)
            {
                TemperatureCollection = new SeriesCollection
                {
                    new LineSeries
                    { Title = ForecastDays[0].Date, Values = new ChartValues < double >(temperatures[0]) },
                    new LineSeries
                    { Title = ForecastDays[1].Date, Values = new ChartValues < double >(temperatures[1]) },
                    new LineSeries
                    { Title = ForecastDays[2].Date, Values = new ChartValues < double >(temperatures[2]) }
                };
                SnowingChancesCollection = new SeriesCollection
                {
                    new LineSeries
                    { Title = ForecastDays[0].Date, Values = new ChartValues < double >(snowing[0]) },
                    new LineSeries
                    { Title = ForecastDays[1].Date, Values = new ChartValues < double >(snowing[1]) },
                    new LineSeries
                    { Title = ForecastDays[2].Date, Values = new ChartValues < double >(snowing[2]) }
                };
                RainingChancesCollection = new SeriesCollection
                {
                    new LineSeries
                    { Title = ForecastDays[0].Date, Values = new ChartValues < double >(raining[0]) },
                    new LineSeries
                    { Title = ForecastDays[1].Date, Values = new ChartValues < double >(raining[1]) },
                    new LineSeries
                    { Title = ForecastDays[2].Date, Values = new ChartValues < double >(raining[2]) }
                };


            }
                Labels = new[] {
                    "12 PM","01 AM","02 AM","03 AM","04 AM","05 AM","06 AM","07 AM","08 AM","09 AM","10 AM","11 AM","12 AM"
                    ,"01 PM","02 PM","03 PM","04 PM","05 PM","06 PM","07 PM","08 PM","09 PM","10 PM","11 PM",};
                YFormatter = value => value.ToString();
        }
    }
}
