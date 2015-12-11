using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SIT.KeShe.Web.WebApp
{
    /// <summary>
    /// SensorInfo 的摘要说明
    /// </summary>
    public class SensorInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string filePath = context.Request.MapPath("Index.html");
            string fileContent = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main'>");
            sb.Append("<h1 class='page-header'>传感器节点信息</h1>");
            sb.Append("<div class='row placeholders'>");
            sb.Append("<div class='col-xs-6 col-sm-3 placeholder'>");
            sb.Append("<img data-src='holder.js/200x200/auto/sky' class='img-responsive' alt='Generic placeholder thumbnail'>");
            sb.Append("<h4><a href='#'>温湿度传感器</a></h4></div>");
            sb.Append("<div class='col-xs-6 col-sm-3 placeholder'>");
            sb.Append("<img data-src='holder.js/200x200/auto/sky' class='img-responsive' alt='Generic placeholder thumbnail'>");
            sb.Append("<h4><a href='#'>光传感器</a></h4></div>");


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