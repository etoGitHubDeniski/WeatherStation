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
        public static Frame FrameDepartment;

        //DataGrids
        public static DataGrid DataGridDeviceInfo;
        public static DataGrid DataGridDepartmentInfo;
        public static DataGrid DataGridDepartmentDeviceInfo;

        //TextBoxes
        public static TextBox TextBoxDeviceSearch; 
        public static TextBox TextBoxDepartmentSearch;
        public static TextBox TextBoxDepartmentProfileSearch;

        //DataBases
        public static WeatherStationAuthorizationEntities WeatherStationAuthorizationDataBase;
        public static WeatherStationEntities WeatherStationDataBase;

        //Logic
        public static int LogicDepartmentDeviceInfo = 0;
    }
}
