using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    abstract class BasicWeatherData:ISubject
    {
        protected List<IObserver> _observers;
        protected double _temperature;
        protected double _humidity;
        protected double _pressure;
        protected char _temperatureUnit;
        protected DateTime _updateTime;
        
        public BasicWeatherData()
        {
        _observers = new List<IObserver>();
        TemperatureUnit = 'F';
            _updateTime = DateTime.Now;
        }
        public double Temperature { get => _temperature; set => _temperature = value; }
        public char TemperatureUnit { get => _temperatureUnit; set => _temperatureUnit = value; }
        public void ChangeTemperatureUnitToCelsius()
        {
            if (TemperatureUnit == 'F')
            {
                this.Temperature = (double)Math.Round((5.0 / 9.0) * (Temperature - 32), 1);
                TemperatureUnit = 'C';
            }
        }
        public void SetMeasurements(double temp, double hum, double press)
        {
            this.Temperature = temp;
            this._humidity = hum;
            this._pressure = press;
            MeasurementsChanged();
        }
        public void ChangeTemperatureUnitToFahrenheit()
        {
            if (TemperatureUnit == 'C')
            {
                this.Temperature = Math.Round((double)32 + (9.0 / 5.0) * Temperature, 1);
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Temp:{_temperature} degrees {_temperatureUnit}\t{_humidity}%\t{_pressure}hPa");
            return sb.ToString();
        }
    }
}
