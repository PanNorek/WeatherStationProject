using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherData : ISubject
    {
        
        List<IObserver> _observers;
        double _temperature;
        double _humidity;
        double _pressure;
       // DateTime _updateTime;

        public WeatherData()
        {
            _observers = new List<IObserver>();  
            //_temperature = default;
            //_humidity = default;
            //_pressure = default;
           // _updateTime = DateTime.Now;
        }
      

        public void NotifyObservers()
        {
            foreach (IObserver obs in _observers)
            {
                obs.Update(_temperature, _humidity, _pressure);
            }
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
        public void SetMeasurements(double temp, double hum, double press)
        {
            this._temperature = temp;
            this._humidity = hum;
            this._pressure = press;
            MeasurementsChanged();
        }
    }
}
//sortowanie po dacie