using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class StatisticDisplay :  IDisplayElement
    {
       
        
        
        string _stationName;
        (int, int) _position;
       List<SpecifedWeatherData> _WeatherStationData;
       
      

        

       //public StatisticDisplay(IDataStationSubject weatherData)
       //{
       //    _WeatherStationData = new List<SpecifedWeatherData>();
       //
       //    this._weatherDataStation = weatherData;
       //    _weatherDataStation.RegisterObserver(this);
       //}

        public void Display()
        {
            Console.WriteLine($"Min/Max temp: {FindMinMaxTemperature().Item1}/{FindMinMaxTemperature().Item2} AVG: {CalculateAverageTemperature()}");
        }


        public void Update(string stationName, (int, int) position, List<SpecifedWeatherData> currentWeathers)
        {
            _stationName = stationName;
            _position = position;
            _WeatherStationData = currentWeathers;
            Display();
        }
        public (double,double) FindMinMaxTemperature()
        {            
            var tmp = this._WeatherStationData.First<SpecifedWeatherData>().Temperature;
            double max = tmp;
            double min = tmp;
            foreach (SpecifedWeatherData item in _WeatherStationData)
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
        public double CalculateAverageTemperature()
        {
            double sum = 0;
            foreach (var item in this._WeatherStationData)
            {
                sum += item.Temperature;
            }
            return (double)sum / (_WeatherStationData.Count());

        }
    }
}
