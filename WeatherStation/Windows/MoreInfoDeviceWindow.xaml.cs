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

        private void BtnWinState_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                BtnWinState.Content = Char.ConvertFromUtf32(0xE922);
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                this.WindowState = WindowState.Normal;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                BtnWinState.Content = Char.ConvertFromUtf32(0xE923);
                this.WindowState = WindowState.Maximized;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                BtnWinState.Content = Char.ConvertFromUtf32(0xE923);
                BtnWinState.ToolTip = "Восстановить";
                GridMain.Margin = new Thickness(7);
            }
            else
            {
                BtnWinState.Content = Char.ConvertFromUtf32(0xE922);
                BtnWinState.ToolTip = "Развернуть";
                GridMain.Margin = new Thickness(0);
            }
        }
    }
}
