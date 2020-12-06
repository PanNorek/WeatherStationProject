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
            WeatherData weatherData = new WeatherData();
            CurrentConditionDisplay currentDisplay = new CurrentConditionDisplay(weatherData);
            StatisticDisplay statisticsDisplay = new StatisticDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);
            weatherData.SetMeasurements(80, 65, 30.4);
            weatherData.SetMeasurements(82, 70, 29.4);
            weatherData.SetMeasurements(78, 90, 29.4);
            weatherData.ChangeTemperatureUnitToCelsius();
            Console.WriteLine(weatherData.Temperature +" "+ weatherData.TemperatureUnit);
            Console.ReadLine();
        }
    }
}
