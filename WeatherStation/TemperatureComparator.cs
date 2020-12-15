using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    //ograniczenie - zawsze pokaze temperature w st. C - chyba ze zrobimy drugi comparator
    class TemperatureComparator : IComparer<SpecifedWeatherData>
    {
        public int Compare(SpecifedWeatherData other, SpecifedWeatherData other2)
        {
            if (other.TemperatureUnit == other2.TemperatureUnit)
            {
                return other.Temperature.CompareTo(other2.Temperature);
            }
            else
            {
                other.ChangeTemperatureUnitToCelsius();
                other2.ChangeTemperatureUnitToCelsius();
                return other.Temperature.CompareTo(other2.Temperature);
            }
        }
    }
}
