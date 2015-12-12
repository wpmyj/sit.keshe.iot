using SIT.KeShe.Web.BLL;
using SIT.KeShe.Web.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SIT.KeShe.Web.WebApp
{
    /// <summary>
    /// SendDataP 的摘要说明
    /// 接收pc程序传来的传感器节点数据
    /// 保存到数据库中
    /// </summary>
    public class SendDataP : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            SendDataBLL sdb = new SendDataBLL();
            SensorData sd = new SensorData();
            sd.Node = context.Request.QueryString["node"];
            sd.Sensor = context.Request.QueryString["sensor"];
            sd.V1 = context.Request.QueryString["v1"];
            sd.V2 = context.Request.QueryString["v2"];
            sd.DTTime = DateTime.Parse(context.Request.QueryString["datetime"]);
            sdb.AddSensor(sd);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}