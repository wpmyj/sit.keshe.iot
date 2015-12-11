using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace SIT.KeShe.Web.WebApp
{
    /// <summary>
    /// About 的摘要说明
    /// </summary>
    public class About : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string filePath = context.Request.MapPath("Index.html");
            string fileContent = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class='col-sm-9 col-sm-offset-3 col-md-10 col-md-offset-2 main'>");
            sb.Append("<h1 class='page-header'>关于</h1>");
            sb.Append("<div>");
            sb.Append("<p class='lead'>本系统略有粗陋，若有好点子，欢迎指点。</p>");
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