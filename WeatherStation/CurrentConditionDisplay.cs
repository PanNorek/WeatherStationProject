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
        ISubject _weatherData;
        public CurrentConditionDisplay(ISubject weatherData)
        {
            this._weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }
        public void Display()
        {
            Console.WriteLine($"Current conditions: {_temperature} C degrees, humidity: {_humidity}%");
        }

        public void Update(double temp, double humidity, double pressure)
        {
            this._temperature = temp;
            this._humidity = humidity;
            Display();
        }
    }
}
