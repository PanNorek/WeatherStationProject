using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    abstract class BasicWeatherData
    {
        
        protected double _temperature;
        protected double _humidity;
        protected double _pressure;
        protected char _temperatureUnit;
        protected DateTime _updateTime;
        
        public BasicWeatherData()
        {
        
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
       
        public void ChangeTemperatureUnitToFahrenheit()
        {
            if (TemperatureUnit == 'C')
            {
                this.Temperature = Math.Round((double)32 + (9.0 / 5.0) * Temperature, 1);
                TemperatureUnit = 'F';
            }
        }
     

    

    

   
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Data: {_updateTime}\tTemp:{_temperature} degrees {_temperatureUnit}\t{_humidity}%\t{_pressure}hPa\t");
            return sb.ToString();
        }
    }
}
