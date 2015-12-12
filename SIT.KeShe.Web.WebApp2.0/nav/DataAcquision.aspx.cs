using SIT.KeShe.Web.BLL;
using SIT.KeShe.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIT.KeShe.Web.WebApp2._0.nav
{
    public partial class DataAcquision : System.Web.UI.Page
    {
        public List<string> lsNode = new List<string>();
        public List<string> lsSensor = new List<string>();
        public List<string> lsSensorType = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            SensorData sd = new SensorData();
            RetrieveBll reBll = new RetrieveBll();
            lsNode = reBll.RetrieveNode();
            lsSensor = reBll.RetrieveSensor();
            for (int i = 0; i < reBll.RetrieveSensor().Count; i++)
            {
                lsSensorType.Add( sd.SensorType[int.Parse(reBll.RetrieveSensor()[i])]);
            }
        }
    }
}