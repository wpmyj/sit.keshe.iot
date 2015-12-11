using SIT.KeShe.Web.DAL;
using SIT.KeShe.Web.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SIT.KeShe.Web.BLL
{
    public class RetrieveBll
    {
        RetrieveDal rdal = new RetrieveDal(); 
        public List<string> RetrieveNode()
        {
            List<string> ls = new List<string>();
            foreach (DataRow row in rdal.RetrieveNode().Rows)
            {
                ls.Add(row[0].ToString());
            }
            return ls;
        }
        public List<string> RetrieveSensor()
        {
            List<string> ls = new List<string>();
            foreach (DataRow row in rdal.RetrieveSensor().Rows)
            {
                ls.Add(row[0].ToString());
            }
            return ls;
        }
        public List<SensorData> RetrieveSensorInfo(string sensor, string node)
        {
            SensorData sd = new SensorData();
            List<SensorData> lsd = new List<SensorData>();
            foreach (DataRow row in rdal.RetrieveSensorInfo(sensor,node).Rows)
            {
                sd.Node = row[0].ToString();
                sd.Sensortype = row[1].ToString();
                sd.V1 = row[2].ToString();
                sd.V2 = row[3].ToString();
                sd.DTTime = (DateTime)row[4];
                lsd.Add(sd);
            }
            return lsd;
        }
    }
}
