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
    /// Логика взаимодействия для InfoDepartmentPage.xaml
    /// </summary>
    public partial class InfoDepartmentPage : Page
    {
        public InfoDepartmentPage()
        {
            InitializeComponent();

            // Запрос всей информации
            var departmentDataList = ControlClass.WeatherStationDataBase.Departament
                .Join(ControlClass.WeatherStationDataBase.WorkProfile,
                    d => d.IdWorkProfile,
                    wp => wp.Id,
                    (d, wp) => new { Departament = d, WorkProfile = wp })
                .Select(s => new
                {
                    s.Departament.Id,
                    s.Departament.Name,
                    WorkProfile = s.WorkProfile.Name
                }).ToList();

            // Вывод информации при открытии страницы
            DgInfoDepartment.ItemsSource = departmentDataList;
            TxbAllDepartmentCount.Text = departmentDataList.Count.ToString();
            TxbNowDepartmentCount.Text = DgInfoDepartment.Items.Count.ToString();
        }

        private void BtnBackToDataMenu_Click(object sender, RoutedEventArgs e)
        {
            // Возврат назад
            ControlClass.FrameMain.GoBack();
        }

        private void TxbSearchInfoDepartment_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Запрос всей информации еще раз, я не знаю как сделать его public
            var departmentDataList = ControlClass.WeatherStationDataBase.Departament
                .Join(ControlClass.WeatherStationDataBase.WorkProfile,
                    d => d.IdWorkProfile,
                    wp => wp.Id,
                    (d, wp) => new { Departament = d, WorkProfile = wp })
                .Select(s => new
                {
                    s.Departament.Id,
                    s.Departament.Name,
                    WorkProfile = s.WorkProfile.Name
                }).ToList();

            if (TxbSearchInfoDepartment.Text != string.Empty)
            {
                // Вывод информации с условием
                DgInfoDepartment.ItemsSource = departmentDataList
                    .Where(x => x.Name.ToUpper().Contains(TxbSearchInfoDepartment.Text.ToUpper()))
                    .Select(x => new { x.Name, x.WorkProfile })
                    .ToList();
            }
            else
            {
                // Вывод всей информации при пустом условии
                DgInfoDepartment.ItemsSource = departmentDataList
                    .Select(x => new { x.Name, x.WorkProfile });
            }

            // Обновление информации
            TxbAllDepartmentCount.Text = departmentDataList.Count.ToString();
            TxbNowDepartmentCount.Text = DgInfoDepartment.Items.Count.ToString();
        }

        private void BtnLookInfoDepartment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
