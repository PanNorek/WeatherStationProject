using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class PM2p5Comparator : IComparer<SpecifedWeatherData>
    {
        public int Compare(SpecifedWeatherData x, SpecifedWeatherData y)
        {
            return x.PM2p5.CompareTo(y.PM2p5);
        }
    }
}
