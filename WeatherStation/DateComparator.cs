using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class DateComparator : IComparer<SpecifedWeatherData>
    {
        public int Compare(SpecifedWeatherData x, SpecifedWeatherData y)
        {
            return x.UpdateTime.CompareTo(y.UpdateTime);
        }
    }
}
