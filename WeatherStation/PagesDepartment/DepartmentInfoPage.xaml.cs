using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WeatherStation.Windows;

namespace WeatherStation.PagesDepartment
{
    /// <summary>
    /// Логика взаимодействия для DepartmentInfoPage.xaml
    /// </summary>
    public partial class DepartmentInfoPage : Page
    {
        public DepartmentInfoPage()
        {
            InitializeComponent();

            ControlClass.DataGridDepartmentDeviceInfo = DgDeviceList;

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

            if (ControlClass.TextBoxDepartmentProfileSearch.Text != string.Empty)
            {
                if (ControlClass.TextBoxDepartmentSearch.Text != string.Empty)
                {
                    // Вывод информации с условием
                    ControlClass.DataGridDepartmentInfo.ItemsSource = departmentDataList
                        .Where(x => x.Name.ToUpper().Contains(ControlClass.TextBoxDepartmentSearch.Text.ToUpper()))
                        .Where(x => x.WorkProfile.ToUpper().Contains(ControlClass.TextBoxDepartmentProfileSearch.Text.ToUpper()))
                        .Select(x => new { x.Name, x.WorkProfile })
                        .ToList();
                }
                else
                {
                    // Вывод информации с условием
                    ControlClass.DataGridDepartmentInfo.ItemsSource = departmentDataList
                        .Where(x => x.WorkProfile.ToUpper().Contains(ControlClass.TextBoxDepartmentProfileSearch.Text.ToUpper()))
                        .Select(x => new { x.Name, x.WorkProfile })
                        .ToList();
                }
            }
            else
            {
                if (ControlClass.TextBoxDepartmentSearch.Text != string.Empty)
                {
                    // Вывод информации с условием
                    ControlClass.DataGridDepartmentInfo.ItemsSource = departmentDataList
                        .Where(x => x.Name.ToUpper().Contains(ControlClass.TextBoxDepartmentSearch.Text.ToUpper()))
                        .Select(x => new { x.Name, x.WorkProfile })
                        .ToList();
                }
                else
                {
                    // Вывод всей информации при пустом условии
                    ControlClass.DataGridDepartmentInfo.ItemsSource = departmentDataList
                        .Select(x => new { x.Name, x.WorkProfile });
                }
            }

            var selectedIndex = ControlClass.DataGridDepartmentInfo.SelectedIndex;

            TxbDepartmentName.Text = departmentDataList[selectedIndex].Name;
            TxbDepartmentWorkProfile.Text = departmentDataList[selectedIndex].WorkProfile;

            var deviceDataList = ControlClass.WeatherStationDataBase.Device
                .Join(ControlClass.WeatherStationDataBase.Status,
                    d => d.IdStatus,
                    sts => sts.Id,
                    (d, sts) => new { Device = d, Status = sts })
                .Join(ControlClass.WeatherStationDataBase.State,
                    x => x.Device.IdState,
                    stt => stt.Id,
                    (x, stt) => new { x.Device, x.Status, State = stt })
                .Join(ControlClass.WeatherStationDataBase.Departament,
                    x => x.Device.IdDepartment,
                    dprt => dprt.Id,
                    (x, dprt) => new { x.Device, x.Status, x.State, Departament = dprt })
                .Join(ControlClass.WeatherStationDataBase.WorkProfile,
                    x => x.Departament.IdWorkProfile,
                    wprf => wprf.Id,
                    (x, wprf) => new { x.Device, x.Status, x.State, x.Departament, WorkProfile = wprf })
                .Join(ControlClass.WeatherStationDataBase.Verification,
                    x => x.Device.Id,
                    vrf => vrf.IdDevice,
                    (x, vrf) => new { x.Device, x.Status, x.State, x.Departament, x.WorkProfile, Verification = vrf })
                .Join(ControlClass.WeatherStationDataBase.Suitability,
                    x => x.Verification.IdSuitability,
                    stb => stb.Id,
                    (x, stb) => new { x.Device, x.Status, x.State, x.Departament, x.WorkProfile, x.Verification, Suitability = stb })
                .Select(s => new
                {
                    s.Device.Id,
                    s.Device.Name,
                    s.Device.Designation,
                    s.Device.InventoryNumber,
                    s.Device.Price,
                    Status = s.Status.Name,
                    State = s.State.Name,
                    IdDepartament = s.Departament.Id,
                    Departament = s.Departament.Name,
                    WorkProfile = s.WorkProfile.Name,
                    Verification = s.Verification.NextDate
                }).ToList();

            DgDeviceList.ItemsSource = deviceDataList
                .Where(x => x.IdDepartament == departmentDataList[selectedIndex].Id)
                .Select(x => new { x.Name, x.Designation, x.Status })
                .ToList();
        }

        private void BtnLookInfoDevice_Click(object sender, RoutedEventArgs e)
        {
            ControlClass.LogicDepartmentDeviceInfo = 2;
            MoreInfoDeviceWindow moreInfoDeviceWindow = new MoreInfoDeviceWindow();
            moreInfoDeviceWindow.Show();
        }

        private void BtnCloseDepartment_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }
    }
}
