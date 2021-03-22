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
    /// Логика взаимодействия для DataMenuPage.xaml
    /// </summary>
    public partial class DataMenuPage : Page
    {
        public DataMenuPage()
        {
            InitializeComponent();
        }

        private void BtnInfoDevice_Click(object sender, RoutedEventArgs e)
        {
            ControlClass.FrameMain.Navigate(new InfoDevicePage());
        }

        private void BtnInfoDepartment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnInfoRepair_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeviceQuantity_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeviceOnVerif_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeviceDecom_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeviceNeedVerif_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDepartmentDeviceOnVerif_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDeviceHaveNextVerif_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
