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
        (int,int) _position;

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
        public WeatherDataStation(string stationname, (int,int) position):this()
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID Stacji: {_idNumber} Nazwa: {_stationName}\t współrzędne:{_position.Item1},{_position.Item2}");
            foreach (var item in _WeatherStationData)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

    }
}
