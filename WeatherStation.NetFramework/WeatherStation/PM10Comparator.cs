using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class PM10Comparator : IComparer<SpecifedWeatherData>
    {
        public int Compare(SpecifedWeatherData x, SpecifedWeatherData y)
        {
            return x.PM10.CompareTo(y.PM10);
        }
    }
}
