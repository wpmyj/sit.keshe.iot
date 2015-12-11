using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SIT.KeShe.Web.WebApp
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    public class Index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string filePath = context.Request.MapPath("Index.html");
            string fileContent = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main'>");
            sb.Append("<h1 class='page-header'>分布式数据采集/控制系统</h1>");
            sb.Append("<div>");
            sb.Append("<p class='lead'>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp该系统可以对二个或以上的实验箱上的温湿度传感器、光照传感器的数据进行采集、显示和管理，并且可以控制每个传感器节点上的黄、蓝LED的打开和关闭，以及LED的闪烁。</p>");
            sb.Append("</div></div>");

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