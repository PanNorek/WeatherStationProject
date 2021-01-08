using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WeatherStation
{
    public class WStationDbContext : DbContext
    {

        public DbSet<SpecifedWeatherData> SpecifedWeatherDatas { get; set; }
        public DbSet<MainStation> MainStationData { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<WeatherDataStation> WeatherDataStations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"FileName={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DatabaseForWeatherStation.sqlite")}");
        }
    }
}
