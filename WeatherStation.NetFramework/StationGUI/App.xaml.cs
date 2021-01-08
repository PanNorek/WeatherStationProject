using System.Windows;
using WeatherStation;
using WeatherStationDatabase;

namespace StationGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (var dbContext = new WeatherStationDbContext())
            {

            }
        }
    }
}
