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
            //CurrentConditionDisplay currentDisplay = new CurrentConditionDisplay(weatherData1);
            //CurrentConditionDisplay currentDisplay2 = new CurrentConditionDisplay(weatherData2);
            //StatisticDisplay statisticsDisplay = new StatisticDisplay(weatherData1);
           // ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData1);
            weatherData1.SetAllMeasurements(80, 65, 1012,25,30);
            weatherData2.SetMeasurements(82, 70, 1006);
            weatherData3.SetAllMeasurements(78, 90, 1000,25,30);
            WeatherDataStation station1 = new WeatherDataStation("Krakow",(2,3));
            station1.Push(weatherData1);
            station1.Push(weatherData2);
            station1.Push(weatherData3);
            //weatherData4.SetMeasurements(130, 60, 1012);
            Console.WriteLine(station1);
            Console.ReadLine();
        }
    }
}
