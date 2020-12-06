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
        //double _humidity;
        double _pressure;
        private double _PM10;
        private double _PM2p5;

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
        public void Update(double temp, double humidity, double pressure, double pm10, double pm2p5)
        {
            Update(temp, humidity, pressure);
            this._PM10 = pm10;
            this._PM2p5 = pm2p5;
            Display();
        }
    }
}
