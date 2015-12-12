using SIT.KeShe.Web.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SIT.KeShe.Web.DAL
{
    public class RetrieveDal
    {
        /// <summary>
        /// 查询节点
        /// </summary>
        /// <returns></returns>
        public DataTable RetrieveNode()
        {
            string sql = "select distinct node from sensor";
            return SqlHelper.GetTable(sql, CommandType.Text);
        }
        /// <summary>
        /// 查询传感器
        /// </summary>
        /// <returns></returns>
        public DataTable RetrieveSensor()
        {
            string sql = "select distinct sensor from sensor";
            return SqlHelper.GetTable(sql, CommandType.Text);
        }
        /// <summary>
        /// 查询节点传感器信息
        /// </summary>
        /// <param name="sensor"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public DataTable RetrieveSensorInfo(string node, string sensor)
        {
            string sql = "select node,sensor,v1,v2,datetime from sensor where sensor=@Sen and node=@Nod";
            SqlParameter[] pars = {
            new SqlParameter("@Sen",SqlDbType.VarChar,20),
            new SqlParameter("@Nod",SqlDbType.VarChar,20)};
            pars[0].Value = sensor;
            pars[1].Value = node;

            return SqlHelper.GetTable(sql, CommandType.Text, pars);
        }
    }
}
