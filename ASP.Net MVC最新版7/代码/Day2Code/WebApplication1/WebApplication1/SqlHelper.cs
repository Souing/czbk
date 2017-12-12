using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public static class SqlHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public static int ExecuteNonQuery(string sql, params SqlParameter[] paramters)
        {
            using(SqlConnection conn = new SqlConnection(connStr))
            using(SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paramters);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] paramters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paramters);
                return cmd.ExecuteScalar();
            }
        }

        public static DataTable ExecuteQuery(string sql, params SqlParameter[] paramters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = conn.CreateCommand())
            using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                conn.Open();
                cmd.CommandText = sql;
                cmd.Parameters.AddRange(paramters);                
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
