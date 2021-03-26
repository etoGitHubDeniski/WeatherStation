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

namespace WeatherStation.PagesDevice
{
    /// <summary>
    /// Логика взаимодействия для DeviceInfoPage.xaml
    /// </summary>
    public partial class DeviceInfoPage : Page
    {
        public DeviceInfoPage()
        {
            InitializeComponent();

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
                }).Where(x => x.Name.ToUpper().Contains(ControlClass.TextBoxDeviceSearch.Text.ToUpper())).ToList();

            var selectedIndex = ControlClass.DataGridDeviceInfo.SelectedIndex;

            TxbDeviceName.Text = deviceDataList[selectedIndex].Name;
            TxbDeviceDesignation.Text = deviceDataList[selectedIndex].Designation;
            TxbDeviceNumber.Text = deviceDataList[selectedIndex].InventoryNumber;
            TxbDevicePrice.Text = deviceDataList[selectedIndex].Price.ToString();
            TxbDeviceStatus.Text = deviceDataList[selectedIndex].Status;
            TxbDeviceState.Text = deviceDataList[selectedIndex].State;
            TxbDeviceDepartment.Text = deviceDataList[selectedIndex].Departament;
            TxbDeviceWorkProfile.Text = deviceDataList[selectedIndex].WorkProfile;

            //DateTime конвертер
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(deviceDataList[selectedIndex].Verification).ToLocalTime();

            TxbDeviceNextDateVerif.Text = dtDateTime.ToString();
        }

        private void BtnCloseDevice_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow.Close();
        }

        private void BtnDeleteDevice_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure? No matter, it's not working!");
        }
    }
}
