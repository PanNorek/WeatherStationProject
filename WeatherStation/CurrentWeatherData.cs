using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class CurrentWeatherData :BasicWeatherData, ISubject
    {
        
        
        double _PM10;
        double _PM2p5;
        List<IObserver> _observers;


        // DateTime _updateTime;

        public CurrentWeatherData() : base()
        {
            _observers = new List<IObserver>();
        }
        public CurrentWeatherData(double pm10, double pm2p5):this()
        {
            _PM2p5 = pm2p5;
            _PM10 = pm10;
        }
        public void SetAllMeasurements(double temp, double hum, double press,double pm10,double pm25)
        {
            this.Temperature = temp;
            this._humidity = hum;
            this._pressure = press;
            this._PM2p5 = pm25;
            this._PM10 = pm10;
            AllMeasurementsChanged();
        }
        public void SetMeasurements(double temp, double hum, double press)
        {
            this.Temperature = temp;
            this._humidity = hum;
            this._pressure = press;
            MeasurementsChanged();
        }

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);

        }
        public void RemoveObserver(IObserver o)
        {
            int i = _observers.IndexOf(o);
            if (i >= 0)
            {
                _observers.RemoveAt(i);
            }

        }
        public void MeasurementsChanged()
        {
            NotifyObservers();
        } 
        public void AllMeasurementsChanged()
        {
            NotifyObserversAboutTotalInfo();
        }
        public  void NotifyObservers()
        {
            foreach (IObserver obs in _observers)
            {
                obs.Update(Temperature, _humidity, _pressure);
            }
        }
        public  void NotifyObserversAboutTotalInfo()
        {
            foreach (IObserver obs in _observers)
            {
                obs.Update(Temperature, _humidity, _pressure,_PM10,_PM2p5);
            }
        }
        public override string ToString()
        {
            if (_PM10!=default || _PM2p5!=default)
            return base.ToString() + $"PM10: {_PM10}qg\t PM2.5:{_PM2p5}qg";

            return base.ToString();
        }


    }
}
//sortowanie po dacie