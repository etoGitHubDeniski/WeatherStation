﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WeatherStation.AppData
{
    class ControlClass
    {
        public static Frame FrameMain;

        public static WeatherStationAuthorizationEntities WeatherStationAuthorizationDataBase;
        public static WeatherStationEntities WeatherStationDataBase;
    }

    class AccountHelpClass
    {
        public static int Id { get; set; }
    }
}