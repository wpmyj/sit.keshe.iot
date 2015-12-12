using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIT.KeShe.Web.Model;
using System.Data.SqlClient;
using System.Data;

namespace SIT.KeShe.Web.DAL
{
    public class SendDataDal
    {
        public int AddSensor(SensorData sd)
        {
            string sql = "insert into Sensor (node,sensor,v1,v2,datetime) values (@node,@sensor,@v1,@v2,@datetime)";
            SqlParameter[] pars =
            {
                new SqlParameter("@node",SqlDbType.VarChar,20),
                new SqlParameter("@sensor",SqlDbType.VarChar,20),
                new SqlParameter("@v1",SqlDbType.VarChar,20),
                new SqlParameter("@v2",SqlDbType.VarChar,20),
                new SqlParameter("@datetime",SqlDbType.DateTime)
            };
            pars[0].Value = sd.Node;
            pars[1].Value = sd.Sensor;
            pars[2].Value = sd.V1;
            pars[3].Value = sd.V2;
            pars[4].Value = sd.DTTime;
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
        }
    }
}
