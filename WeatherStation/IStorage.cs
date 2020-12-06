using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    interface IStorage
    {
        bool Push(CurrentWeatherData o);
        CurrentWeatherData ShowLastItem();


    }
}
