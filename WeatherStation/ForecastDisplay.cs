using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class ForecastDisplay : IObserver, IDisplayElement
    {
        double _temperature;
        double _humidity;
        double _pressure;
        public ForecastDisplay(ISubject weatherData)
        {

        }
        public void Display()
        {
            Console.WriteLine("Here it'll be a forecast");
        }

        public void Update(double temp, double humidity, double pressure)
        {
            this._temperature = temp;
            this._pressure = humidity;
            this._pressure = pressure;
            Display();
        }
    }
}
