using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherDataStation:Station,IStorage//, IDataStationSubject
    {
        
        (int,int) _position;
        //List<IDataStationObserver> _dataStationObservers;

        List<SpecifedWeatherData> _WeatherStationData;
        
        public WeatherDataStation():base()
        {
            _WeatherStationData = new List<SpecifedWeatherData>();

        }
        public WeatherDataStation(string name, (int,int) position):base(name)
        {
            _WeatherStationData = new List<SpecifedWeatherData>();
            // _dataStationObservers = new List<IDataStationObserver>();
            Position = position;

        }

        public (int, int) Position { get => _position; set => _position = value; }

        // public void MeasurementsChanged()
        // {
        //     NotifyObservers();
        // }


        // public void NotifyObservers()
        //{
        //    foreach (IDataStationObserver obs in _dataStationObservers)
        //    {
        //        obs.Update(_stationName, _position, _WeatherStationData);
        //    }
        //}

        public bool Push(SpecifedWeatherData o)
        {
            if (o != null)
            {
                _WeatherStationData.Add(o);                

                return true;
            }
            return false;
        }
       
      //public void RegisterObserver(IDataStationObserver o)
      //{
      //    _dataStationObservers.Add(o);
      //}
      //
      //public void RemoveObserver(IDataStationObserver o)
      //{
      //    int i = _dataStationObservers.IndexOf(o);
      //    if (i >= 0)
      //    {
      //        _dataStationObservers.RemoveAt(i);               
      //    }
      //}

        public SpecifedWeatherData ShowLastItem()
        {
            return(SpecifedWeatherData) _WeatherStationData.Last<SpecifedWeatherData>();
        }

       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID Stacji: {_id} Nazwa: {_stationName}\t współrzędne:{Position.Item1},{Position.Item2}");
            foreach (var item in _WeatherStationData)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

    }
}
