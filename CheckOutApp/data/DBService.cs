using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOutApp.data
{
    class DBService
    {
        public static bool Login(string username, string password)
        {
            bool flag = true;
            string sqlText = "select count(*) from operator  where username = @username and password = @password";
            OleDbParameter[] parameters = new OleDbParameter[] { new OleDbParameter("@username", username) , new OleDbParameter("@password", password) };
            int i = (int)SqlHelper.ExecuteScalar(sqlText, parameters);
            if (i > 0)
            {
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
    }
}
