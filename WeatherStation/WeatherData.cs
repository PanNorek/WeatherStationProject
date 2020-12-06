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
        char _temperatureUnit;

        public double Temperature { get => _temperature; set => _temperature = value; }
        public char TemperatureUnit { get => _temperatureUnit; set => _temperatureUnit = value; }

        // DateTime _updateTime;

        public WeatherData()
        {
            _observers = new List<IObserver>();
            TemperatureUnit = 'F';
            //_temperature = default;
            //_humidity = default;
            //_pressure = default;
           // _updateTime = DateTime.Now;
        }
      
        public void ChangeTemperatureUnitToCelsius()
        {
            if (TemperatureUnit == 'F')
            {
                this.Temperature =(double) (5.0 / 9.0) * (Temperature - 32);
                TemperatureUnit = 'C';
            }
        }
        public void ChangeTemperatureUnitToFahrenheit()
        {
            if (TemperatureUnit == 'C')
            {
                this.Temperature = (double)32 + (9.0 / 5.0) * Temperature;
                TemperatureUnit = 'F';
            }
        }

        public void NotifyObservers()
        {
            foreach (IObserver obs in _observers)
            {
                obs.Update(Temperature, _humidity, _pressure);
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
            this.Temperature = temp;
            this._humidity = hum;
            this._pressure = press;
            MeasurementsChanged();
        }
    }
}
//sortowanie po dacie