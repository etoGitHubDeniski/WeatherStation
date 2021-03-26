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
using System.Windows.Shapes;
using WeatherStation.AppData;
using WeatherStation.PagesDevice;

namespace WeatherStation.Windows
{
    /// <summary>
    /// Логика взаимодействия для MoreInfoDeviceWindow.xaml
    /// </summary>
    public partial class MoreInfoDeviceWindow : Window
    {
        public MoreInfoDeviceWindow()
        {
            InitializeComponent();

            ControlClass.WeatherStationDataBase = new WeatherStationEntities();

            ControlClass.FrameDevice = FrmDevice;
            ControlClass.FrameDevice.Navigate(new DeviceInfoPage());
        }

        private void BtnRollUp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
