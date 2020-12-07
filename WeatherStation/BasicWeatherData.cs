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
        private double humidity;
        private double pressure;
        private char _temperatureUnit;
        private DateTime updateTime;

        public BasicWeatherData()
        {
        
        TemperatureUnit = 'C';
            UpdateTime = DateTime.Now;
        }
        public double Temperature { get => _temperature; set => _temperature = value; }
        public char TemperatureUnit { get => _temperatureUnit; set => _temperatureUnit = value; }
        public double Humidity { get => humidity; set => humidity = value; }
        public double Pressure { get => pressure; set => pressure = value; }
        public DateTime UpdateTime { get => updateTime; set => updateTime = value; }

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
            sb.Append($"Data: {UpdateTime}\tTemp:{_temperature} degrees {TemperatureUnit}\t{Humidity}%\t{Pressure}hPa\t");
            return sb.ToString();
        }
    }
}
