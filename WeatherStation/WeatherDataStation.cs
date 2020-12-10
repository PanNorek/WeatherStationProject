
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace WeatherStation
{
    [Serializable]
    class WeatherDataStation : Station, IStorage,ICloneable
    {

        string _position;

        List<SpecifedWeatherData> _WeatherStationData;

        public WeatherDataStation() : base()
        {
            WeatherStationData = new List<SpecifedWeatherData>();

        }
        public WeatherDataStation(string name, string position) : base(name)
        {
            WeatherStationData = new List<SpecifedWeatherData>();
            // _dataStationObservers = new List<IDataStationObserver>();
            Position = position;

        }

        public string Position { get => _position; set => _position = value; }
        public List<SpecifedWeatherData> WeatherStationData { get => _WeatherStationData; set => _WeatherStationData = value; }

        public bool Push(SpecifedWeatherData o)
        {
            if (o != null)
            {
                WeatherStationData.Add(o);

                return true;
            }
            return false;
        }


        public SpecifedWeatherData ShowLastItem()
        {
            return (SpecifedWeatherData)WeatherStationData.Last<SpecifedWeatherData>();
        }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"ID Stacji: {Id} Nazwa: {_stationName}\t współrzędne:{Position}");
            foreach (var item in WeatherStationData)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        public void SaveDataStationtoJSON(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                JavaScriptSerializer json = new JavaScriptSerializer();
                sw.WriteLine(json.Serialize(this));
            }
        }
        public void SaveDataStationtoJSON()
        {
            string filename = this._stationName + ".json";
            using (StreamWriter sw = new StreamWriter(filename))
            {
                JavaScriptSerializer json = new JavaScriptSerializer();
                sw.WriteLine(json.Serialize(this));
            }
        }
        public static WeatherDataStation LoadDataStationJSON(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            using (StreamReader sw = new StreamReader(fileName))
            {
                JavaScriptSerializer json = new JavaScriptSerializer();
                string z = sw.ReadToEnd();
                return (WeatherDataStation)json.Deserialize<WeatherDataStation>(z);
                //Deserialize(z, typeof(WeatherDataStation));
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        public void TemperatureCalsiusSort()
        {
            _WeatherStationData.Sort(new TemperatureComparator());
        }
        public void TemperatureCalsiusSort(bool sortType)
        {
            bool sortMethod = false;
            sortMethod = sortType;
            if (sortMethod == false) { _WeatherStationData.Sort(new TemperatureComparator()); }
            else {
                _WeatherStationData.Sort(new TemperatureComparator());
                _WeatherStationData.Reverse();
            }
        }
        public void HumiditySort()
        {
            _WeatherStationData.Sort(new HumidityComparator());
        }
        public void HumiditySort(bool sortType)
        {
            
            bool sortMethod = false;
            sortMethod = sortType;
            if (sortMethod == false) { _WeatherStationData.Sort(new HumidityComparator()); }
            else
            {
                _WeatherStationData.Sort(new HumidityComparator());
                _WeatherStationData.Reverse();
            }
        }
        public void PressureSort()
        {
            _WeatherStationData.Sort(new PressureComparator());
        }
        public void PressureSort(bool sortType)
        {
            
            bool sortMethod = false;
            sortMethod = sortType;
            if (sortMethod == false) { _WeatherStationData.Sort(new PressureComparator()); }
            else
            {
                _WeatherStationData.Sort(new PressureComparator());
                _WeatherStationData.Reverse();
            }
        }
        public void DateSort()
        {
            _WeatherStationData.Sort(new DateComparator());
        }
        public void DateSort(bool sortType)
        {

            bool sortMethod = false;
            sortMethod = sortType;
            if (sortMethod == false) { _WeatherStationData.Sort(new DateComparator()); }
            else
            {
                _WeatherStationData.Sort(new DateComparator());
                _WeatherStationData.Reverse();
            }
        }
        public void PM10Sort()
        {
            _WeatherStationData.Sort(new PM10Comparator());
        }
        public void PM10Sort(bool sortType)
        {

            bool sortMethod = false;
            sortMethod = sortType;
            if (sortMethod == false) { _WeatherStationData.Sort(new PM10Comparator()); }
            else
            {
                _WeatherStationData.Sort(new PM10Comparator());
                _WeatherStationData.Reverse();
            }
        } 
        public void PM2p5Sort()
        {
            _WeatherStationData.Sort(new PM2p5Comparator());
        }
        public void PM2p5Sort(bool sortType)
        {

            bool sortMethod = false;
            sortMethod = sortType;
            if (sortMethod == false) { _WeatherStationData.Sort(new PM2p5Comparator()); }
            else
            {
                _WeatherStationData.Sort(new PM2p5Comparator());
                _WeatherStationData.Reverse();
            }
        }

    }
}
