﻿using System;
using System.Text;

namespace WeatherStation
{

    [Serializable]
    public abstract class BasicWeatherData:ICloneable
    {
        
          
        private double _humidity,_pressure, _temperature;
        private string _temperatureUnit;
        private DateTime _updateTime;

        public BasicWeatherData()
        {
        
            TemperatureUnit = "C";
            UpdateTime = DateTime.Now;
        }
        public double Temperature { get => _temperature; set => _temperature = value; }
        public string TemperatureUnit { get => _temperatureUnit; set => _temperatureUnit = value; }
        public double Humidity { get => _humidity; set => _humidity = value; }
        public double Pressure { get => _pressure; set => _pressure = value; }
        public DateTime UpdateTime { get => _updateTime; set => _updateTime = value; }

        public void ChangeTemperatureUnitToCelsius()
        {
            if (TemperatureUnit == "F")
            {
                this.Temperature = (double)Math.Round((5.0 / 9.0) * (Temperature - 32), 1);
                TemperatureUnit = "C";
            }
        }
       
        public void ChangeTemperatureUnitToFahrenheit()
        {
            if (TemperatureUnit == "C")
            {
                this.Temperature = Math.Round((double)32 + (9.0 / 5.0) * Temperature, 1);
                TemperatureUnit = "F";
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Data: {UpdateTime}\tTemp:{_temperature} degrees {TemperatureUnit}\t{Humidity}%\t{Pressure}hPa\t");
            return sb.ToString();
        }
    }
}
