using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherDataStation:IStorage
    {
        static int _idNumber;
        string _stationName;
        int[,] _position;

        List<CurrentWeatherData> _WeatherStationData;
        static WeatherDataStation()
        {
            _idNumber = 1;
        }
        public WeatherDataStation()
        {
            _WeatherStationData = new List<CurrentWeatherData>();
            _idNumber++;
        }
        public WeatherDataStation(string stationname, int [,] position):this()
        {
            _stationName = stationname;
            _position = position;
        }
        public bool Push(CurrentWeatherData o)
        {
            if (o != null)
            {
                _WeatherStationData.Add(o);
                return true;
            }
            return false;
        }

        public CurrentWeatherData ShowLastItem()
        {
            return(CurrentWeatherData) _WeatherStationData.Last<CurrentWeatherData>();
        }


    }
}
