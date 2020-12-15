using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
     public class WeatherDataStationObserver : IObservable<WeatherDataStation>
    {
        
        List<IObserver<WeatherDataStation>> _observers;
        public WeatherDataStationObserver()
        {
            _observers = new List<IObserver<WeatherDataStation>>();
        }
        public IDisposable Subscribe(IObserver<WeatherDataStation> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }
        private class Unsubscriber : IDisposable
        {
            private List<IObserver<WeatherDataStation>> _observers;
            private IObserver<WeatherDataStation> _observer;

            public Unsubscriber(List<IObserver<WeatherDataStation>> observers, IObserver<WeatherDataStation> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
        public void TrackWeatherStation(WeatherDataStation loc)
        {
            foreach (var observer in _observers.ToList<IObserver<WeatherDataStation>>())
            {
                if (loc is null)
                    observer.OnError(new WeatherUnknownException());
                else
                    observer.OnNext(loc);
            }
        }
        public void EndTransmission()
        {
            foreach (var observer in _observers.ToArray())
                if (_observers.Contains(observer))
                    observer.OnCompleted();

            _observers.Clear();
        }
    }
     
}
