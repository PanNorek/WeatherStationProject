using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrentWeatherData weatherData1 = new CurrentWeatherData();
            CurrentWeatherData weatherData2 = new CurrentWeatherData();
            CurrentWeatherData weatherData3 = new CurrentWeatherData();
            CurrentWeatherData weatherData4 = new CurrentWeatherData();
            CurrentConditionDisplay currentDisplay = new CurrentConditionDisplay(weatherData1);
            StatisticDisplay statisticsDisplay = new StatisticDisplay(weatherData1);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData1);
            weatherData1.SetMeasurements(80, 65, 1012);
            weatherData2.SetMeasurements(82, 70, 1006);
            weatherData3.SetMeasurements(78, 90, 1000);
            weatherData4.SetMeasurements(130, 60, 1012);
            
            Console.ReadLine();
        }
    }
}
