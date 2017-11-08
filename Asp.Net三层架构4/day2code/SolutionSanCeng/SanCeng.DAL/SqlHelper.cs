using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanCeng.DAL
{
    class SqlHelper
    {
        //ConfigurationManager是读取UI项目的config！！！
        private static string connStr =
            ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;

        public static void ExecuteNonQuery(string sql,params SqlParameter[] parameters)
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            using(SqlCommand cmd = conn.CreateCommand())//new SqlCommand(),cmd.Connection=this;
           // using(SqlCommand cmd = new SqlCommand())
            {
                conn.Open();
               // cmd.Connection = conn;
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql,params SqlParameter[] parameters)
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        /*
        public static DataTable ExecuteQuery(string sql,params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                DataTable dt = new DataTable();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);                    
                }
                return dt;
            }
        }*/

        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(parameters);
                DataSet ds = new DataSet();//一个DataSet可以包含多个DataTable
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))// cmd.ExecuteReader() Fill
                {
                    adapter.Fill(ds);
                }
                return ds.Tables[0];
            }
        }
    }
}
