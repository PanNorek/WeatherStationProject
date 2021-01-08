using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using WeatherStation;

namespace WeatherUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainStation _mainStation;
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public MainStation MainStationWindowData { get => _mainStation; set => _mainStation = value; }

        public MainWindow()
        {
            InitializeComponent();
            Timer.Tick += new EventHandler(Timer_Click);

            Timer.Interval = new TimeSpan(0, 0, 1);

            Timer.Start();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
           // Microsoft.Win32.FileDialog file = 
        }
        private void Timer_Click(object sender, EventArgs e)

        {

            DateTime d;

            d = DateTime.Now;

            label1.Content = d.Hour + " : " + d.Minute + " : " + d.Second;
            label2.Content = d.Day + "/" + d.Month + "/" + d.Year;

        }

        private void Forecast_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChooseStation_Click(object sender, RoutedEventArgs e)
        {
            StationsListWindow window = new StationsListWindow(this, MainStationWindowData);
            
            this.Hide();
            window.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LoadData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                MainStationWindowData = MainStation.LoadDataStationJSON(openFileDialog.FileName);
            }
                
        }
    }
}
