using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIT.KeShe.Web.Model
{
    public class SensorData
    {
        public string Node { get; set; }
        public string Sensortype { get; set; }
        public string V1 { get; set; }
        public string V2 { get; set; }
        public DateTime DTTime { get; set; }

        public string[] Sensor = { "","温湿度传感器","","光传感器"};

    }
}
