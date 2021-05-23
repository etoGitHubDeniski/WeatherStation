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
using WeatherStation.PagesDepartment;

namespace WeatherStation.Windows
{
    /// <summary>
    /// Логика взаимодействия для MoreInfoDepartmentWindow.xaml
    /// </summary>
    public partial class MoreInfoDepartmentWindow : Window
    {
        public MoreInfoDepartmentWindow()
        {
            InitializeComponent();

            ControlClass.WeatherStationDataBase = new WeatherStationEntities();

            ControlClass.FrameDepartment = FrmDepartment;
            ControlClass.FrameDepartment.Navigate(new DepartmentInfoPage());
        }

        private void BtnRollUp_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Не костыль, а временное решение проблемы
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Topmost = false;
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
