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

namespace StationGUI
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
            //menu
            List<MenuItem> menu = new List<MenuItem>();
            menu.Add(new MenuItem("Add Data", PackIconKind.Plus, new ItemCount(Brushes.Black, 2)));
            menu.Add(new MenuItem("Statistics", PackIconKind.Table, new ItemCount(Brushes.DarkBlue, 4)));
            menu.Add(new MenuItem("Forecast", PackIconKind.WeatherCloudy, new ItemCount(Brushes.DarkGreen, 7)));
            menu.Add(new MenuItem("Exit", PackIconKind.ExitRun, new ItemCount(Brushes.Red, 3)));
            ListViewMenu.ItemsSource = menu;

            //zegar
            Timer.Tick += new EventHandler(Timer_Click);

            Timer.Interval = new TimeSpan(0, 0, 1);

            Timer.Start();

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
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                _mainStation.SaveDataStationtoJSON(filename);
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
    }
}
