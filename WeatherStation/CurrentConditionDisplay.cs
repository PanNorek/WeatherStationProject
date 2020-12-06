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
            sb.AppendLine($"Current conditions: {Math.Round(_temperature,1)} C degrees, humidity: {_humidity}%, pressure: {_pressure} hPa");
            if (_PM2p5 != default && _PM10!= default)
            {
                sb.AppendLine($"PM10:{_PM10}\tPM2.5:{_PM2p5}");
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
            Update(temp, humidity, pressure);
            this._PM10 = pm10;
            this._PM2p5 = pm2p5;
            Display();
        }
    }
}
