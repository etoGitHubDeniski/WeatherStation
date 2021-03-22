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
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void BtnAddDevice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemoveDevice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLookData_Click(object sender, RoutedEventArgs e)
        {
            ControlClass.FrameMain.Navigate(new LookDataPage());
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            ControlClass.FrameMain.Navigate(new LoginPage());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
