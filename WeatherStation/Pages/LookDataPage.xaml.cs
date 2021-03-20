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

            //var workProfile = ControlClass.WeatherStationDataBase.WorkProfile.FirstOrDefault(x => x.Id == AccountHelpClass.Id);
            //ControlClass.WeatherStationDataBase.Device.ToList();

            DgAllDevicesData.ItemsSource = ControlClass.WeatherStationDataBase.Device
                .Join(ControlClass.WeatherStationDataBase.Status,
                    device => device.IdStatus,
                    status => status.Id,
                    (device, status) => new { Device = device, Status = status })
                .Join(ControlClass.WeatherStationDataBase.State,
                    device => device.IdState,
                    state => state.Id,
                    (device, state) => new { Device = device, State = state })
                .Select(x => new {
                    Name = x.Device.Name,
                    Designation = x.Device.Designation,
                    InventoryName = x.Device.InventoryNumber,
                    Price = x.Device.Price,
                    IdStatus = x.Status.Name,
                    IdState = x.State.Name})
                .ToList();
        }
    }
}
