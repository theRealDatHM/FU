﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Q2_PE
{
    class Database
    {
        public static SqlConnection GetConnection()
        {
            string strCon = ConfigurationManager.ConnectionStrings["PE"].ToString();
            return new SqlConnection(strCon);
        }

        public static DataTable GetDataBySQL(string sql)
        {

            SqlCommand sqlCommand = new SqlCommand(sql, GetConnection());
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;
            DataSet ds = new DataSet(); // database cache
            adapter.Fill(ds);
            return ds.Tables[0];
        }

        public static int ExecuteSQL(string sql, params SqlParameter[] sqlParameters)
        {
            SqlCommand cmd = new SqlCommand(sql, GetConnection()); // giống ps
            cmd.Parameters.AddRange(sqlParameters);
            cmd.Connection.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return result;
        }
    }
}
