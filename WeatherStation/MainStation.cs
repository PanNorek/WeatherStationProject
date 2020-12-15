using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    [Serializable]
    class MainStation:Station
    {
        Dictionary<int, WeatherDataStation> _setOfWeatherstations;

        
        public MainStation():base()
        {
            _setOfWeatherstations = new Dictionary<int, WeatherDataStation>();
        }
        public MainStation(string name):base(name)
        {
            _setOfWeatherstations = new Dictionary<int, WeatherDataStation>();
        }
        public bool AddWeatherStationToMainStation(WeatherDataStation w)
        {
            if (w == null)
            {
                throw new Exception("Nie ma takiej stacji!");
            }

            _setOfWeatherstations.Add(w.Id, w);
            return true;
            
        }
    }
}
