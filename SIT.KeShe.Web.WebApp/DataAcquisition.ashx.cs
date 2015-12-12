using SIT.KeShe.Web.BLL;
using SIT.KeShe.Web.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SIT.KeShe.Web.WebApp
{
    /// <summary>
    /// DataAcquisition 的摘要说明
    /// </summary>
    public class DataAcquisition : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            RetrieveBll rbll = new RetrieveBll();
            SensorData sd = new SensorData();
            List<string> node= rbll.RetrieveNode();
            List<string> sensor = rbll.RetrieveSensor();
            string filePath = context.Request.MapPath("Index.html");
            string fileContent = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main'>");
            sb.Append("<h1 class='page-header'>实时数据监控</h1>");
            sb.Append("<div class='row placeholders'><div class='col-xs-6 col-sm-3 placeholder'><form>");
            sb.Append("<select class='form-control' id='selectNode'>");
            sb.Append("<option value=''>请选择节点</option>");
            foreach (var nd in node)
            {
                sb.Append("<option value='"+nd+"'>" + nd+ "</option>");
            }
            sb.Append("</select></form></div>");
            sb.Append("<div class='col-xs-6 col-sm-3 placeholder'><form>");
            sb.Append("<select class='form-control' id='selectSensor'>");
            sb.Append("<option value=''>请选择传感器</option>");
            foreach (var se in sensor)
            {
                sb.Append("<option value='"+se+"'>" + sd.Sensor[int.Parse(se)] + "</option>");
            }
            sb.Append("</select></form></div>");
            sb.Append("<div class='col-xs-6 col-sm-3 placeholder'>");
            sb.Append("<button class='btn btn-default btn-block' type='submit' id='searchData'>查询</button></div></div>");

            string node1 = "";
            string sensor1 = "";
            node1 = context.Request.QueryString["node"];
            sensor1 = context.Request.QueryString["sensor"];
            if (node1!=""&&sensor1!="")
            {
                sb.Append("<div class='table-responsive'>");
                sb.Append("<table class='table table-striped'>");
                List<SensorData> lsd = rbll.RetrieveSensorInfo(sensor1, node1);
                if (sensor1 == "1")
                {
                    sb.Append("<thead><tr><th>#</th><th>节点</th><th>传感器</th><th>温度</th><th>湿度</th><th>时间</th></tr></thead>");
                    for (int i = 0; i < lsd.Count; i++)
                    {
                        sb.Append("<tbody><tr><td>" + (i + 1) + "</td><td>" + lsd[i].Node + "</td><td>" + lsd[i].Sensor + "</td><td>" + lsd[i].V1 + "</td><td>" + lsd[i].V2 + "</td><td>" + lsd[i].DTTime + "</td></tr></tbody>");
                    }
                }
                if (sensor1 == "3")
                {
                    sb.Append("<thead><tr><th>#</th><th>节点</th><th>传感器</th><th>光照</th><th>时间</th></tr></thead>");
                    for (int i = 0; i < lsd.Count; i++)
                    {
                        sb.Append("<tbody><tr><td>" + (i + 1) + "</td><td>" + lsd[i].Node + "</td><td>" + lsd[i].Sensor + "</td><td>" + lsd[i].V1 + "</td><td>" + lsd[i].DTTime + "</td></tr></tbody>");
                    }
                }
                sb.Append("</div>");
            }
            sb.Append("</div>");

            fileContent = fileContent.Replace("$dbody", sb.ToString());
            context.Response.Write(fileContent);
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