using SIT.KeShe.Web.BLL;
using SIT.KeShe.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SIT.KeShe.Web.WebApp2._0.nav
{
    /// <summary>
    /// DAjson 的摘要说明
    /// </summary>
    public class DAjson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string node= context.Request["node"]??"0";
            string sensor = context.Request["sensor"]??"0";
            RetrieveBll reBll = new RetrieveBll();
            var ls= reBll.RetrieveSensorInfo(node, sensor);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(ls);
            context.Response.Write(json);
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