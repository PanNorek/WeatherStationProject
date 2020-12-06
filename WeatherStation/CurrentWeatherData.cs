using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class CurrentWeatherData :BasicWeatherData
    {
        
        
        double _PM10;
        double _PM2p5;



        // DateTime _updateTime;

        public CurrentWeatherData() : base()
        {
            _PM2p5 = default;
            _PM10 = default;
        }
        public CurrentWeatherData(double pm10, double pm2p5)
        {
            _PM2p5 = pm2p5;
            _PM10 = pm10;
        }
        public void SetMeasurements(double temp, double hum, double press,double pm10,double pm25)
        {
            this.Temperature = temp;
            this._humidity = hum;
            this._pressure = press;
            this._PM2p5 = pm25;
            this._PM10 = pm10;
            MeasurementsChanged();
        }
       new  public void NotifyObservers()
        {
            foreach (IObserver obs in _observers)
            {
                obs.Update(Temperature, _humidity, _pressure,_PM10,_PM2p5);
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"PM10: {_PM10}\t PM2.5:{_PM2p5}";
        }


    }
}
//sortowanie po dacie