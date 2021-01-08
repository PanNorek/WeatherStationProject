using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    class WeatherStationForecastReporter: IObserver<WeatherDataStation>
    {
        private IDisposable _unsubscriber;
        private string _instName;

        public WeatherStationForecastReporter(string name)
        {
            this._instName = name;
        }

        public string Name
        { get { return this._instName; } }
        public virtual void Subscribe(IObservable<WeatherDataStation> provider)
        {
            if (provider != null)
                _unsubscriber = provider.Subscribe(this);
        }


        public void OnCompleted()
        {
            Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", this.Name);
            this.Unsubscribe();
        }
        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
        public void OnError(Exception error)
        {
            Console.WriteLine("{0}: The location cannot be determined.", this.Name);
        }

        public void OnNext(WeatherDataStation value)
        {
            Console.WriteLine("{1}: The current location is {0}", value.Position, this.Name);
            foreach (var item in value.WeatherStationData)
            {
                Console.WriteLine(item);
            }
            this.Unsubscribe();
        }
    }

}
