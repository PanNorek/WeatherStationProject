using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using WeatherStation;

namespace WeatherStation.Database
{
    public class WeatherStationDbContext:DbContext
    {   
        public DbSet<SpecifedWeatherData> SpecifedWeatherDatas { get; set; }
        public DbSet<MainStation> MainStationData { get; set; }
        public DbSet<WeatherDataStation> WeatherDataStations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"FileName={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"DatabaseForWeatherStation.sqlite")}");
        }
    }
}
