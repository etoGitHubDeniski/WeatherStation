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
    /// Логика взаимодействия для LookDataPage.xaml
    /// </summary>
    public partial class LookDataPage : Page
    {
        public LookDataPage()
        {
            InitializeComponent();

            ControlClass.FrameData = FrmData;
            ControlClass.FrameData.Navigate(new DataMenuPage());

            //DgAllDevicesData.ItemsSource = ControlClass.WeatherStationDataBase.WeatherStationView.ToList();
        }

        private void BtnBackToMenu_Click(object sender, RoutedEventArgs e)
        {
            ControlClass.FrameMain.GoBack();
        }
    }
}
