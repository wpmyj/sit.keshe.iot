using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIT.KeShe.Web.DAL;
using SIT.KeShe.Web.Model;

namespace SIT.KeShe.Web.BLL
{
    public class SendDataBLL
    {
        SendDataDal sdd = new SendDataDal();
        /// <summary>
        /// 向数据库添加节点数据
        /// </summary>
        /// <param name="sd">节点</param>
        /// <returns></returns>
        public bool AddSensor(SensorData sd)
        {
            return sdd.AddSensor(sd)>0;
        }
    }
}
