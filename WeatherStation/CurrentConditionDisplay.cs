using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class CurrentConditionDisplay:IObserver,IDisplayElement
    {
        double _temperature;
        double _humidity;
        double _pressure;
        double _PM10;
        double _PM2p5;
        ISubject _weatherData;
        
        public CurrentConditionDisplay(ISubject weatherData)
        {
            this._weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }
        public void Display()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Current conditions: {Math.Round(_temperature,1)} C degrees, humidity: {_humidity}%, pressure: {_pressure} hPa\t");
            if (_PM2p5 != default && _PM10!= default)
            {
                sb.Append($"PM10:{_PM10}qg\tPM2.5:{_PM2p5}qg");
            }
            Console.WriteLine(sb.ToString());
        }

        public void Update(double temp, double humidity, double pressure)
        {
            this._temperature = temp;
            this._humidity = humidity;
            this._pressure = pressure;
            Display();
        }
        public void Update(double temp, double humidity, double pressure, double pm10, double pm2p5)
        {
            this._temperature = temp;
            this._humidity = humidity;
            this._pressure = pressure;
            this._PM10 = pm10;
            this._PM2p5 = pm2p5;
            Display();
        }
    }
}
