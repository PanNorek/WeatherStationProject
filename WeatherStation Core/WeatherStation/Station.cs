using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    [Serializable]
    public abstract class Station
    {
        static int _idNumber;
        private int id;
        protected string _stationName;

        public int Id { get => id; set => id = value; }

        static Station()
        {
            _idNumber = 1;
        }
        public Station()
        {
            Id = _idNumber;//$"{_idNumber}";
            _idNumber++;
        }
        public Station(string name) : this()
        {
            _stationName = name;

        }
        public void ChangeStationName(string name)
        {
            this._stationName = name;
        }
    }
}
