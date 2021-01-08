using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class HumidityComparator : IComparer<SpecifedWeatherData>
    {
        public int Compare(SpecifedWeatherData x, SpecifedWeatherData y)
        {
            return x.Humidity.CompareTo(y.Humidity);
        }
    }
}
