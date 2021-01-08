using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{

    public class StatisticStationReporter : IObserver<WeatherDataStation>
    {
        private IDisposable _unsubscriber;
        private string _instName;

        public StatisticStationReporter(string name)
        {
            this._instName = name;
        }

        public string Name
        { get { return this._instName; } }
        public virtual void Subscribe(IObservable<WeatherDataStation> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }


        public void OnCompleted()
        {
            Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", this.Name);
            this.Unsubscribe();
        }
        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
        public void OnError(Exception error)
        {
            Console.WriteLine("{0}: The location cannot be determined.", this.Name);
        }

        public void OnNext(WeatherDataStation value)
        {
            Console.WriteLine("{1}: The current stations's location is {0}", value.Position, this.Name);
            foreach (var item in value.WeatherStationData)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Dane prezentowane z {0} dni:", value.WeatherStationData.Count());
            Console.WriteLine("Min/Max temp: {0}/{1}", FindMinMaxTemperature(value).Item1, FindMinMaxTemperature(value).Item2);
            Console.WriteLine("Average temp:{0} degrees {1}", Math.Round(CalculateAverageTemperature(value).Item1, 1), CalculateAverageTemperature(value).Item2);
            Console.WriteLine("Average humidity:{0} %", Math.Round(CalculateAverageHumidity(value), 1));
            Console.WriteLine("Average pressure:{0} hPa", Math.Round(CalculateAveragePressure(value), 1));
            Console.WriteLine("Average PM10:{0}qg \t PM2.5:{1}qg", Math.Round(CalculateAveragePM(value).Item1, 1), Math.Round(CalculateAveragePM(value).Item2, 1));
            Console.WriteLine();
            this.Unsubscribe();
        }
        public (double, double) FindMinMaxTemperature(WeatherDataStation station)
        {
            var tmp = station.WeatherStationData.First<SpecifedWeatherData>().Temperature;
            double max = tmp;
            double min = tmp;
            foreach (SpecifedWeatherData item in station.WeatherStationData)
            {
                if (item.Temperature > max)
                {
                    max = item.Temperature;
                }
                if (item.Temperature < min)
                {
                    min = item.Temperature;
                }
            }
            return (min, max);
        }
        public (double, char) CalculateAverageTemperature(WeatherDataStation station)
        {
            double sum = 0;
            foreach (var item in station.WeatherStationData)
            {
                item.ChangeTemperatureUnitToCelsius();
                sum += item.Temperature;
            }
            return ((double)sum / (station.WeatherStationData.Count()), 'C');

        }
        public double CalculateAverageHumidity(WeatherDataStation station)
        {
            double sum = 0;
            foreach (var item in station.WeatherStationData)
            {

                sum += item.Humidity;
            }
            return (double)sum / (station.WeatherStationData.Count());
        }
        public double CalculateAveragePressure(WeatherDataStation station)
        {
            double sum = 0;
            foreach (var item in station.WeatherStationData)
            {

                sum += item.Pressure;
            }
            return (double)sum / (station.WeatherStationData.Count());
        }
        public (double, double) CalculateAveragePM(WeatherDataStation station)
        {
            double sum = 0;
            double sum2 = 0;
            foreach (var item in station.WeatherStationData)
            {

                sum += item.PM10;
                sum2 += item.PM2p5;
            }
            return (sum / station.WeatherStationData.Count(), sum2 / station.WeatherStationData.Count());
        }
    }
}
