using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WeatherStation.AppData
{
    class ControlClass
    {
        // Frames
        public static Frame FrameMain;
        public static Frame FrameData;
        public static Frame FrameDevice;

        //DataGrids
        public static DataGrid DataGridDeviceInfo;

        //TextBoxes
        public static TextBox TextBoxDeviceSearch;

        //DataBases
        public static WeatherStationAuthorizationEntities WeatherStationAuthorizationDataBase;
        public static WeatherStationEntities WeatherStationDataBase;
    }
}
