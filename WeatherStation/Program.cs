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
            SpecifedWeatherData weatherData1 = new SpecifedWeatherData();
            SpecifedWeatherData weatherData2 = new SpecifedWeatherData();
            SpecifedWeatherData weatherData3 = new SpecifedWeatherData();
            SpecifedWeatherData weatherData4 = new SpecifedWeatherData();
            
            //CurrentConditionDisplay currentDisplay2 = new CurrentConditionDisplay(weatherData2);
            
           // ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData1);
            weatherData1.SetAllMeasurements(25, 65, 1012,25,30);
            weatherData2.SetMeasurements(28, 70, 1006);
            weatherData3.SetAllMeasurements(23, 90, 1000,25,30);
            WeatherDataStation station1 = new WeatherDataStation("Krakow",(2,3));
           WeatherDataStation station2 = new WeatherDataStation("Katowice",(3,4));
           WeatherDataStation station3 = new WeatherDataStation("Katowice",(3,4));
            station1.Push(weatherData1);
            station1.Push(weatherData2);
            station1.Push(weatherData3);
            //weatherData4.SetMeasurements(130, 60, 1012);
            MainStation motherstation = new MainStation("Stacja Główna");
            motherstation.AddWeatherStationToMainStation(station1);
            motherstation.AddWeatherStationToMainStation(station2);
            
            Console.WriteLine(station1);
            Console.WriteLine(station2);
            Console.WriteLine(station3);
            Console.ReadLine();
        }
    }
}
