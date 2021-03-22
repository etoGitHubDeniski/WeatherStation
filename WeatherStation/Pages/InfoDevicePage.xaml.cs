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
using WeatherStation.AppData;

namespace WeatherStation.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfoDevicePage.xaml
    /// </summary>
    public partial class InfoDevicePage : Page
    {
        public InfoDevicePage()
        {
            InitializeComponent();
            DgInfoDevice.ItemsSource = ControlClass.WeatherStationAuthorizationDataBase.User.ToList();
        }

        private void BtnBackToDataMenu_Click(object sender, RoutedEventArgs e)
        {
            ControlClass.FrameMain.GoBack();
        }

        private void TxbSearchInfoDevice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TxbSearchInfoDevice.Text != string.Empty)
            {
                DgInfoDevice.ItemsSource = ControlClass.WeatherStationAuthorizationDataBase.User.Where(x => x.Login.Contains(TxbSearchInfoDevice.Text)).ToList();
            }
            else
            {
                DgInfoDevice.ItemsSource = ControlClass.WeatherStationAuthorizationDataBase.User.ToList();
            }
        }

        private void BtnLookInfoDevice_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
