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
using WeatherStation.Windows;

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

            ControlClass.DataGridDeviceInfo = DgInfoDevice;
            ControlClass.TextBoxDeviceSearch = TxbSearchInfoDevice;

            // Запрос всей информации
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
                    Departament = s.Departament.Name,
                    WorkProfile = s.WorkProfile.Name,
                    Verification = s.Verification.NextDate
                }).ToList();

            // Вывод информации при открытии страницы
            DgInfoDevice.ItemsSource = deviceDataList
                .Select(x => new { x.Name, x.Designation, x.Status });
            TxbAllDeviceCount.Text = deviceDataList.Count.ToString();
            TxbNowDeviceCount.Text = DgInfoDevice.Items.Count.ToString();
            TxbWorkDeviceCount.Text = deviceDataList
                .Where(x => x.Status == "Работет")
                .Select(x => new { x.Name, x.Designation, x.Status }).ToList().Count.ToString();
        }

        private void BtnBackToDataMenu_Click(object sender, RoutedEventArgs e)
        {
            // Возврат назад
            ControlClass.FrameMain.GoBack();
        }

        private void TxbSearchInfoDevice_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Запрос всей информации еще раз, я не знаю как сделать его public
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
                    Departament = s.Departament.Name,
                    WorkProfile = s.WorkProfile.Name,
                    Verification = s.Verification.NextDate
                }).ToList();

            if (TxbSearchInfoDevice.Text != string.Empty)
            {
                // Вывод информации с условием
                DgInfoDevice.ItemsSource = deviceDataList
                    .Where(x => x.Name.ToUpper().Contains(TxbSearchInfoDevice.Text.ToUpper()))
                    .Select(x => new { x.Name, x.Designation, x.Status })
                    .ToList();
            }
            else
            {
                // Вывод всей информации при пустом условии
                DgInfoDevice.ItemsSource = deviceDataList
                    .Select(x => new { x.Name, x.Designation, x.Status });
            }

            // Обновление информации
            TxbAllDeviceCount.Text = deviceDataList.Count.ToString();
            TxbNowDeviceCount.Text = DgInfoDevice.Items.Count.ToString();
            TxbWorkDeviceCount.Text = deviceDataList
                .Where(x => x.Status == "Работет")
                .Select(x => new { x.Name, x.Designation, x.Status }).ToList().Count.ToString();
        }

        private void BtnLookInfoDevice_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна с дополнительной информацией
            ControlClass.LogicDepartmentDeviceInfo = 1;
            MoreInfoDeviceWindow moreInfoDeviceWindow = new MoreInfoDeviceWindow();
            moreInfoDeviceWindow.Show();
        }
    }
}
