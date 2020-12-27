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
            
            CurrentConditionDisplay currentDisplay2 = new CurrentConditionDisplay(weatherData1);
            
           // ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData1);
            weatherData1.SetAllMeasurements(25, 65, 1012,25,30);
            // Console.WriteLine("||||||||||||||||||||||");
            weatherData2.SetMeasurements(28, 70, 1006);
            weatherData3.SetAllMeasurements(23, 90, 1000,25,30);
            WeatherDataStation station1 = new WeatherDataStation("Krakow", "50.0647° N, 19.9450° E");

            WeatherDataStation station2 = new WeatherDataStation("Katowice", "50.0647° N, 19.9450° E");
            WeatherDataStation station3 = new WeatherDataStation("Katowice", "50.0647° N, 19.9450° E");
            station1.Push(weatherData1);
            station1.Push(weatherData2);
            station1.Push(weatherData3);
            //weatherData4.SetMeasurements(130, 60, 1012);
            MainStation motherstation = new MainStation("StacjaGłówna");
            motherstation.AddWeatherStationToMainStation(station1);
            motherstation.AddWeatherStationToMainStation(station2);
            motherstation.SaveDataStationtoJSON();
            //Console.WriteLine(station1);
            ///Console.WriteLine(station2);
            ///Console.WriteLine(station3);


            WeatherDataStationObserver provider = new WeatherDataStationObserver();
            StatisticStationReporter reporter1 = new StatisticStationReporter("FixedGPS");
            reporter1.Subscribe(provider);
            StatisticStationReporter reporter2 = new StatisticStationReporter("MobileGPS");
            //reporter2.Subscribe(provider);
            //
            provider.TrackWeatherStation(station1);
            reporter1.Unsubscribe();
            //provider.TrackWeatherStation(station2);
            provider.TrackWeatherStation(null);
            provider.EndTransmission();
            station1.SaveDataStationtoJSON();
            station3 = WeatherDataStation.LoadDataStationJSON("Krakow.json");
            weatherData1.SaveDatatoJSON("test.json");
            weatherData4 = SpecifedWeatherData.OdczytajJSON("test.json");
            //Console.WriteLine("|||||||||||");
            //Console.WriteLine(weatherData4);
            //Console.WriteLine("|||||||||||");
            //Console.WriteLine(station3);
            //Console.WriteLine("|||||||||||comparator");
            //station1.TemperatureCalsiusSort(true);
            //Console.WriteLine(station1);
            //Console.WriteLine("|||||||||||comparatorfalse");
            //station1.TemperatureCalsiusSort();
            //Console.WriteLine(station1);
            Console.ReadLine();
        }
    }
}
