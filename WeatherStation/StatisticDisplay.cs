using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class StatisticDisplay : IObserver, IDisplayElement
    {
        double _temperature;

        double _min;
        double _average;
        double _max;
        ISubject _weatherData;
        double _PM10;
        double _PM2p5;

        public StatisticDisplay(ISubject weatherData)
        {
            _min = default;
            _max = default;
            this._weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Display()
        {
            Console.WriteLine($"Min/Avg/Max temperature:{_min}/{_average}/{_max} ");
        }

        public void Update(double temp, double humidity, double pressure)
        {
            this._temperature = temp;
            if (_temperature > _max)
            {
                _max = _temperature;
            }
            if (_min == 0)
            {
                _min = _temperature;
            }
            if (_temperature < _min)
            {
                _min = _temperature;
            }
    
            _average = (_max + _min) / 2;
            Display();
        }
        public void Update(double temp, double humidity, double pressure, double pm10, double pm2p5)
        {
            Update(temp, humidity, pressure);
            this._PM10 = pm10;
            this._PM2p5 = pm2p5;
            Display();
        }
    }
}
