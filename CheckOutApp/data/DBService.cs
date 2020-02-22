using CheckOutApp.entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Text;

namespace CheckOutApp.data
{

    class DBService
    {
        static string conStr = ConfigurationManager.AppSettings["conStr"];
        //登陆验证
        public static bool Login(string username, string password)
        {
            bool flag = false;
            string sqlText = "select * from operator t  where username = @username and password = @password";
            using (OleDbConnection conn = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand(sqlText, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Static_oprator.realname = reader.GetValue(3).ToString();
                            Static_oprator.identity = reader.GetValue(4).ToString();
                        }
                        return flag = true;
                    }
                    else
                    {
                        return flag;
                    }

                }
            }
        }
        //新增记录
        public static int AddLog(CheckoutRecord record) 
        {
            string uuid = DateTime.Now.ToString("yyyyMMddhhmmssffff");
            string inTime = DateTime.Now.ToString();
            string sqlText = "insert into stockout_record (carnumber,totalsum,recordId,payment_method,operator,inTime,totalnumber,company) values (@carNumber,@totalSum,@recordId,@paymentMethod,@recordOperator,@inTime,@totalnumber,@company)";
            OleDbParameter[] parameters = new OleDbParameter[] { new OleDbParameter("@carnumber",record.carNumber), new OleDbParameter("@totalsum", record.totalSum), new OleDbParameter("@recordId",uuid), new OleDbParameter("@paymentMethod",record.paymentMethod), new OleDbParameter("@recordOperator",Static_oprator.realname), new OleDbParameter("@inTime",inTime), new OleDbParameter("@totalnumber",record.totalNumber),new OleDbParameter("@company",record.company) };
            int i = SqlHelper.ExecuteNonQuery(sqlText, parameters);
            return i;
        }
        //
        //新增记录
        public static int AddInCar(string carnumber,string weight,string company,string remark)
        {
            string sqlText = "insert into incar (carnumber,weight,company,remark) values (@carNumber,@weight,@company,@remark)";
            OleDbParameter[] parameters = new OleDbParameter[] { new OleDbParameter("@carnumber", carnumber), new OleDbParameter("@weight", weight), new OleDbParameter("@company", company), new OleDbParameter("@remark", remark)};
            int i = SqlHelper.ExecuteNonQuery(sqlText, parameters);
            return i;
        }
        //获取记录数据
        public static List<CheckoutRecord> GetCheckoutRecords()
        {
            List<CheckoutRecord> list = new List<CheckoutRecord>();
            string query = "select top 30 * from  stockout_record  as t order by inTime desc ";
            OleDbConnection conn = new OleDbConnection(conStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CheckoutRecord record = new CheckoutRecord();
                {
                    record.carNumber = reader.GetValue(1).ToString();
                    record.totalSum = reader.GetValue(2).ToString();
                    record.recordId = reader.GetValue(3).ToString();
                    record.paymentMethod = reader.GetValue(4).ToString();
                    record.recordOperator = reader.GetValue(5).ToString();
                    record.inTime = reader.GetValue(6).ToString();
                    record.totalNumber = reader.GetValue(7).ToString();
                    record.company = reader.GetValue(9).ToString();
                };
                list.Add(record);
            }
            conn.Close();
            return list;
        }
        //获取在场车辆记录
        public static List<InCar> GetInCars()
        {
            List<InCar> list = new List<InCar>();
            string query = "select * from  incar as t ";
            OleDbConnection conn = new OleDbConnection(conStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                InCar car = new InCar();
                {
                    car.carNumber = reader.GetValue(1).ToString();
                    car.carWeight = reader.GetValue(2).ToString();
                    car.company = reader.GetValue(3).ToString();
                    car.remark = reader.GetValue(4).ToString();
                };
                list.Add(car);
            }
            conn.Close();
            return list;
        }
        //获取人员信息
        public static List<User> GetUserInfo()
        {
            List<User> list = new List<User>();
            string query = "select  * from  operator  as t ";
            OleDbConnection conn = new OleDbConnection(conStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User user = new User();
                {
                    user.ID = reader.GetValue(0).ToString();
                    user.username = reader.GetValue(1).ToString();
                    user.password = reader.GetValue(2).ToString();
                    user.realname = reader.GetValue(3).ToString();
                    user.phonenumber = reader.GetValue(5).ToString();
                    user.sex = reader.GetValue(6).ToString();
                };
                list.Add(user);
            }
            conn.Close();
            return list;
        }
        //获取批量打印的记录数据
        public static List<CheckoutRecord> GetCheckoutRecords(string companyName,string startTime,string endTime,string operatorName)
        {
            List<CheckoutRecord> records = new List<CheckoutRecord>();
            StringBuilder sql = new StringBuilder("select * from stockout_record where 1=1 ");
            OleDbConnection conn = new OleDbConnection(conStr);
            if (!companyName.Equals(""))
            {
                sql.Append(string.Format(" and company = '{0}' ", companyName));
            }
            if (!startTime.Equals(""))
            {
                sql.Append(string.Format(" and inTime >= #{0}# ", startTime));
            }
            if (!endTime.Equals(""))
            {
                sql.Append(string.Format(" and inTime <= #{0}# ", endTime));
            }
            if (!operatorName.Equals(""))
            {
                sql.Append(string.Format(" and operator = '{0}' ", operatorName));
            }
            OleDbCommand command = new OleDbCommand(sql.ToString(), conn);
            conn.Open();
            OleDbDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    CheckoutRecord record = new CheckoutRecord();
                    {
                        record.carNumber = reader.GetValue(1).ToString();
                        record.totalSum = reader.GetValue(2).ToString();
                        record.recordId = reader.GetValue(3).ToString();
                        record.paymentMethod = reader.GetValue(4).ToString();
                        record.recordOperator = reader.GetValue(5).ToString();
                        record.inTime = reader.GetValue(6).ToString();
                        record.totalNumber = reader.GetValue(7).ToString();
                        record.company = reader.GetValue(9).ToString();
                    };
                    records.Add(record);
                }
                return records;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
        }
        //删除单据
        public static int DeleteRecord(string recordId)
        {
            string deleteSql = string.Format("delete from stockout_record where recordId = '{0}' ", recordId);
            OleDbConnection conn = new OleDbConnection(conStr);
            conn.Open();
            OleDbCommand odc = new OleDbCommand(deleteSql, conn);
            int i = odc.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        //获取统计数据
        public static Statistics GetStatistics(string startTime, string endTime)
        {
            Statistics statistics = new Statistics();
            StringBuilder sql = new StringBuilder("select count(*),sum(totalsum),sum(totalnumber) from stockout_record where 1=1 ");
            OleDbConnection conn = new OleDbConnection(conStr);
            if (!startTime.Equals(""))
            {
                sql.Append(string.Format(" and inTime >= #{0}# ", startTime));
            }
            if (!endTime.Equals(""))
            {
                sql.Append(string.Format(" and inTime <= #{0}# ", endTime));
            }
            OleDbCommand command = new OleDbCommand(sql.ToString(), conn);
            conn.Open();
            OleDbDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    statistics.count = reader.GetValue(0).ToString();
                    statistics.totalsum = reader.GetValue(1).ToString();
                    statistics.totalnumber = reader.GetValue(2).ToString();
                }
                return statistics;
            }
            finally
            {
                reader.Close();
                conn.Close();
            }
        }
        //新增用户
        public static int AddUser(string username,string password,string realname,string phonenumber,string sex)
        {
            OleDbConnection conn = new OleDbConnection(conStr);
            string sql = string.Format(" INSERT INTO operator ([username],[password],[realname],[identitu],[phonenumber],[sex]) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')", username,password,realname,"0", phonenumber,sex);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        //根据单据号搜索
        public static List<CheckoutRecord> GetCheckoutRecordsById(string recordId)
        {
            List<CheckoutRecord> list = new List<CheckoutRecord>();
            string query = string.Format("select * from  stockout_record  as t where t.recordId = '{0}' order by inTime desc ", recordId);
            OleDbConnection conn = new OleDbConnection(conStr);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CheckoutRecord record = new CheckoutRecord();
                {
                    record.carNumber = reader.GetValue(1).ToString();
                    record.totalSum = reader.GetValue(2).ToString();
                    record.recordId = reader.GetValue(3).ToString();
                    record.paymentMethod = reader.GetValue(4).ToString();
                    record.recordOperator = reader.GetValue(5).ToString();
                    record.inTime = reader.GetValue(6).ToString();
                    record.totalNumber = reader.GetValue(7).ToString();
                    record.company = reader.GetValue(9).ToString();
                };
                list.Add(record);
            }
            conn.Close();
            return list;
        }
    }
}
