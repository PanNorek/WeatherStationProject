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
    public class SpecifedWeatherData :BasicWeatherData, ISubject,ICloneable
    {

        public int Id{ get; set; }
        double _PM10, _PM2p5;        
        List<IObserver> _observers;

        public double PM10 { get => _PM10; set => _PM10 = value; }
        public double PM2p5 { get => _PM2p5; set => _PM2p5 = value; }


         //DateTime _updateTime;

        public SpecifedWeatherData() : base()
        {
            _observers = new List<IObserver>();
        }
        public SpecifedWeatherData(double pm10, double pm2p5):this()
        {
            PM2p5 = pm2p5;
            PM10 = pm10;
        }
        public void SetAllMeasurements(double temp, double hum, double press,double pm10,double pm25)
        {
            this.Temperature = temp;
            this.Humidity = hum;
            this.Pressure = press;
            this.PM2p5 = pm25;
            this.PM10 = pm10;
            AllMeasurementsChanged();
        }
        public void SetMeasurements(double temp, double hum, double press)
        {
            this.Temperature = temp;
            this.Humidity = hum;
            this.Pressure = press;
            MeasurementsChanged();
        }

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
        
        }
        public void RemoveObserver(IObserver o)
        {
            int i = _observers.IndexOf(o);
            if (i >= 0)
            {
                _observers.RemoveAt(i);
            }
        
        }
        public void MeasurementsChanged()
        {
            NotifyObservers();
        }
        public void AllMeasurementsChanged()
        {
            NotifyObserversAboutTotalInfo();
        }
        public  void NotifyObservers()
        {
            foreach (IObserver obs in _observers)
            {
                obs.Update(Temperature, Humidity, Pressure);
            }
        }
        public  void NotifyObserversAboutTotalInfo()
        {
            foreach (IObserver obs in _observers)
            {
                obs.Update(Temperature, Humidity, Pressure,PM10,PM2p5);
            }
        }
        public double CalculatePM10LevelAboveNorm(double pm10)
        {
            //norma PM10: 20 µg/m. norma średniego 24-godz. stężenia pyłu PM2,5: 25 µg/m.
            double PMNorm = 20.0;
            return (Math.Round((pm10 / PMNorm), 1)*100);
        }
        public double CalculatePM2p5LevelAboveNorm(double pm2p5)
        {
            //norma PM10: 20 µg/m. norma średniego 24-godz. stężenia pyłu PM2,5: 25 µg/m.
            double PMNorm = 25.0;
            return (Math.Round((pm2p5 / PMNorm), 1)*100);
        }
        public override string ToString()
        {
            if (PM10!=default || PM2p5!=default)
            return base.ToString() + $"PM10: {PM10}qg ({CalculatePM10LevelAboveNorm(this.PM10)}%)\t PM2.5:{PM2p5}qg({CalculatePM2p5LevelAboveNorm(this.PM2p5)}%)";

            return base.ToString();
        }
        public void SaveDatatoJSON(string fileName)
        {
            
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                JavaScriptSerializer json = new JavaScriptSerializer();
                sw.WriteLine(json.Serialize(this));
            }
        }
        public static SpecifedWeatherData OdczytajJSON(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            using (StreamReader sw = new StreamReader(fileName))
            {
                JavaScriptSerializer json = new JavaScriptSerializer();
                string z = sw.ReadToEnd();
                return (SpecifedWeatherData)json.Deserialize<SpecifedWeatherData>(z);
                
            }
        }

        public new object Clone()
        {
            return MemberwiseClone(); 
        }
    }
}
//sortowanie po dacie