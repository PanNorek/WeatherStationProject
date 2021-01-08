using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    public interface IObserver
    {
        void Update(double temp, double humidity, double pressure);
        void Update(double temp, double humidity, double pressure, double pm10, double pm2p5);

    }
}
