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

namespace WeatherUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WeatherDataStation _weatherStation;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CurrentCondition_Click(object sender, RoutedEventArgs e)
        {
            var currentData = _weatherStation.ShowLastItem();
            CurrentConditionWindow currentConditionWindow = new CurrentConditionWindow();
            //currentConditionWindow.CurrentConditionBox = 
        }

        private void LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;

                _weatherStation = WeatherDataStation.LoadDataStationJSON(filename)
                    ;

                
            }
        }
    }
}
