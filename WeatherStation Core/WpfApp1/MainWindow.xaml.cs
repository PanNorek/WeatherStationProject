using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherStation;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainStation _mainStation;
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        List<DockPanel> docks = new List<DockPanel>();
        List<ComboBox> combos = new List<ComboBox>();
        List<WeatherDataStation> stations = new List<WeatherDataStation>();
        List<SpecifedWeatherData> currentStationHistory = new List<SpecifedWeatherData>();
        List<SpecifedWeatherData> currentStationStatistics = new List<SpecifedWeatherData>();

        WStationDbContext dbContext = new WStationDbContext();

        public MainStation MainStationWindowData { get => _mainStation; set => _mainStation = value; }
        public MainWindow()
        {
                //SpecifedWeatherData weatherData1 = new SpecifedWeatherData();
                //
                //weatherData1.SetAllMeasurements(25, 65, 1012, 25, 30);
                //
                //
                InitializeComponent();
                //menu
                dbContext.Database.EnsureCreated();

            stations.Add(new WeatherDataStation("Kielczanin", "Kielce"));
            stations.Add(new WeatherDataStation("Krakowianin", "Kraków"));
            stations.Add(new WeatherDataStation("Ptak", "Gdańsk"));

            combo.ItemsSource = stations;

            docks.Add(DockAdd);
                docks.Add(DockHistory);
            docks.Add(DockCheck);


            History.ItemsSource = currentStationHistory;


                //zegar
                Timer.Tick += new EventHandler(Timer_Click);

                Timer.Interval = new TimeSpan(0, 0, 1);

                Timer.Start();


                dbContext.SaveChanges();


        }

        private void ClearDocks()
        {
            foreach (DockPanel dock in docks)
            {
                dock.Visibility = Visibility.Hidden;
            }
        }
        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Timer_Click(object sender, EventArgs e)

        {

            DateTime d;

            d = DateTime.Now;
            string seconds = d.Second.ToString();
            string minutes = d.Minute.ToString();
            if (d.Second < 10)
            {
                seconds = "0" + d.Second;
            }
            if (d.Minute < 10)
            {
                minutes = "0" + d.Minute;
            }

            label1.Content = d.Hour + " : " + minutes + " : " + seconds;
            label2.Content = d.Day + "/" + d.Month + "/" + d.Year;

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (combo.SelectedItem != null)
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    int index = combo.SelectedIndex + 1;
                    foreach (SpecifedWeatherData d in dbContext.SpecifedWeatherDatas)
                    {
                        if (d.Station == index)
                        {
                            stations[index-1].WeatherStationData.Add(d);
                        }
                    }
                    string filename = dlg.FileName;
                    stations[index - 1].SaveDataStationtoJSON(filename);
                }
            }       
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                MainStationWindowData = MainStation.LoadDataStationJSON(openFileDialog.FileName);
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearDocks();
            DockAdd.Visibility = Visibility.Visible;
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearDocks();
            DockCheck.Visibility = Visibility.Visible;
        }

        private void HistBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearDocks();
            DockHistory.Visibility = Visibility.Visible;
        }

        private void AddRecord_Click(object sender, RoutedEventArgs e)
        {
            if (combo.SelectedItem != null)
            {
                try {
                    double temp = double.Parse(TemperatureBox.Text);
                    double pres = double.Parse(PressureBox.Text);
                    double humi = double.Parse(HumidityBox.Text);
                    dbContext.SpecifedWeatherDatas.Add(new SpecifedWeatherData(temp, humi, pres, combo.SelectedIndex + 1));
                    dbContext.SaveChanges();
                }
                catch(Exception ex)
                { }
                
            }           
        }

        private void CheckPrognose_Click(object sender, RoutedEventArgs e)
        {
            if (combo.SelectedItem != null)
            {
                List<double> temps = new List<double>();
                List<double> press = new List<double>();
                List<double> humis = new List<double>();
                int index = combo.SelectedIndex + 1;
                currentStationHistory.Clear();
                foreach (SpecifedWeatherData d in dbContext.SpecifedWeatherDatas)
                {
                    if (d.Station == index)
                    {
                        temps.Add(d.Temperature);
                        press.Add(d.Pressure);
                        humis.Add(d.Humidity);                
                    }
                }
                if(temps.Count > 0)
                {
                    CheckTemp.Text = temps.Average().ToString();
                    CheckPres.Text = press.Average().ToString();
                    CheckHumi.Text = humis.Average().ToString();
                }
                History.Items.Refresh();
            }
            

        }

        private void HistSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if(combo.SelectedItem != null)
            {
                int index = combo.SelectedIndex + 1;
                currentStationHistory.Clear();
                foreach (SpecifedWeatherData d in dbContext.SpecifedWeatherDatas)
                {
                    if (d.Station == index)
                    {
                        currentStationHistory.Add(d);
                    }
                }
                History.Items.Refresh();
            }          
        }
    }
}
