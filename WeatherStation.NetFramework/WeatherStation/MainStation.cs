using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{ 
    [Serializable]
   public  class MainStation:Station
    {
        List <WeatherDataStation> _setOfWeatherstations;

        public List<WeatherDataStation> SetOfWeatherstations { get => _setOfWeatherstations; set => _setOfWeatherstations = value; }

        public MainStation():base()
        {
            SetOfWeatherstations = new List<WeatherDataStation>();
        }
        public MainStation(string name):base(name)
        {
            SetOfWeatherstations = new List<WeatherDataStation>();
        }
        public bool AddWeatherStationToMainStation(WeatherDataStation w)
        {
            if (w == null)
            {
                throw new Exception("Nie ma takiej stacji!");
            }

            SetOfWeatherstations.Add(w);
            return true;
            
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
        public static MainStation LoadDataStationJSON(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            using (StreamReader sw = new StreamReader(fileName))
            {
                JavaScriptSerializer json = new JavaScriptSerializer();
                string z = sw.ReadToEnd();
                return (MainStation)json.Deserialize<MainStation>(z);
                
            }
        }
    }
}
