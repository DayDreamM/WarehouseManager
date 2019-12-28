using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CheckOutApp.data
{
    class SqlHelper
    {
        static string conStr = ConfigurationManager.AppSettings["conStr"];
        public static int ExecuteNonQuery(string sqlText, params SqlParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    conn.Open();  //打开数据库
                    cmd.CommandText = sqlText;  //对CommandText进行赋值
                    cmd.Parameters.AddRange(parameters);  //对数据库使用参数进行赋值
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sqlText, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sqlText;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
