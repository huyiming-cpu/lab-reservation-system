
using MySql.Data.MySqlClient;

using System;

using System.Data;


namespace DB


{

    public class MySqlUtil 

    {
        private static string connstr = GetConnectionString();//"server=127.0.0.1;database=zhusu;username=root;password=admin;";

        private static string GetConnectionString() 
        {
            MySqlConnectionStringBuilder strb = new MySqlConnectionStringBuilder();
            strb.Server = "140.143.121.118";
            strb.Port = 3306;
            strb.Database = "lab_reservation_system";
            strb.UserID = "labapp";
            strb.Password = "Lab@123456";
            return strb.ConnectionString;
        }

        //测试数据库连接

        public static bool TestConnection()
        {
            Console.WriteLine(connstr);
            MySqlConnection con = new MySqlConnection(connstr);
            con.Open();           
            Console.WriteLine("数据库连接成功");         
            con.Close();
            Console.ReadKey();
            return true;
        }

             /// 执行带参数的查询语句，返回MySqlDataReader
        public static MySqlDataReader ExecutQuery(string sqlString, params MySqlParameter[] cmdParms) 

        {

            MySqlConnection connection = new MySqlConnection(connstr);

            MySqlCommand cmd = new MySqlCommand();

            MySqlDataReader myReader = null;

            try

            {

                PrepareCommand(cmd, connection, null, sqlString, cmdParms);

                myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                cmd.Parameters.Clear();

                return myReader;

            }

            catch (System.Data.SqlClient.SqlException e)

            {

                connection.Close();

                throw new Exception(e.Message);

            }

            finally

            {

                if (myReader == null)

                {

                    cmd.Dispose();

                    connection.Close();

                }

            }

        }

        /// 执行带参数的sql语句，并返回执行行数

        public static int ExecuteUpdate(string sqlString, params MySqlParameter[] cmdParms) 

        {

            using (MySqlConnection connection = new MySqlConnection(connstr))

            {

                using (MySqlCommand cmd = new MySqlCommand())

                {

                    try

                    {

                        PrepareCommand(cmd, connection, null, sqlString, cmdParms);

                        int rows = cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();

                        return rows;

                    }

                    catch (System.Data.SqlClient.SqlException E)

                    {

                        throw new Exception(E.Message);

                    }

                    finally

                    {

                        cmd.Dispose();

                        connection.Close();

                    }

                }

            }

        }
       
                     

        /// 执行带参数的查询语句，返回DataSet
           

        public static DataSet ExecuteQueryDataSet(string sqlString, params MySqlParameter[] cmdParms) 

        {

            using (MySqlConnection connection = new MySqlConnection(connstr))

            {

                MySqlCommand cmd = new MySqlCommand();

                PrepareCommand(cmd, connection, null, sqlString, cmdParms);

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))

                {

                    DataSet ds = new DataSet();

                    try

                    {

                        da.Fill(ds, "ds");

                        cmd.Parameters.Clear();

                    }

                    catch (System.Data.SqlClient.SqlException ex)

                    {

                        throw new Exception(ex.Message);

                    }

                    finally

                    {

                        cmd.Dispose();

                        connection.Close();

                    }

                    return ds;

                }

            }

        }
         

        /// 执行带参数的sql语句，并返回object 

        public static object GetSingle(string sqlString, params MySqlParameter[] cmdParms)

        {

            using (MySqlConnection connection = new MySqlConnection(connstr))

            {

                using (MySqlCommand cmd = new MySqlCommand())

                {
                    try
                    {

                        PrepareCommand(cmd, connection, null, sqlString, cmdParms);

                        object obj = cmd.ExecuteScalar();

                        cmd.Parameters.Clear();

                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))

                        {

                            return null;

                        }

                        else

                        {

                            return obj;

                        }

                    }

                    catch (System.Data.SqlClient.SqlException e)

                    {

                        throw new Exception(e.Message);

                    }

                    finally

                    {

                        cmd.Dispose();

                        connection.Close();

                    }

                }

            }

        }

        /// 执行存储过程,返回数据集

        public static DataSet RunProcedureForDataSet(string storedProcName, IDataParameter[] parameters)

        {

            using (MySqlConnection connection = new MySqlConnection(connstr))

            {

                DataSet dataSet = new DataSet();

                connection.Open();

                MySqlDataAdapter sqlDA = new MySqlDataAdapter();

                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);

                sqlDA.Fill(dataSet);

                connection.Close();

                return dataSet;

            }

        }

        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)

        private static MySqlCommand BuildQueryCommand(MySqlConnection connection, string storedProcName,

            IDataParameter[] parameters)

        {

            MySqlCommand command = new MySqlCommand(storedProcName, connection);

            command.CommandType = CommandType.StoredProcedure;

            foreach (MySqlParameter parameter in parameters)

            {

                command.Parameters.Add(parameter);

            }

            return command;

        }


        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText,

            MySqlParameter[] cmdParms)

        {

            if (conn.State != ConnectionState.Open)

            {

                conn.Open();

            }

            cmd.Connection = conn;

            cmd.CommandText = cmdText;

            if (trans != null)

            {

                cmd.Transaction = trans;

            }

            cmd.CommandType = CommandType.Text; //cmdType;

            if (cmdParms != null)

            {

                foreach (MySqlParameter parm in cmdParms)

                {

                    cmd.Parameters.Add(parm);

                }

            }

        }



        /*
                // ----- 测试演示------ 
                static void Main(string[] args)
                {

                    // MySqlUtil.TestConnection();
                    string sql = " select * from user where id = @id ";
                    DataSet dataset = MySqlUtil.ExecuteQueryDataSet(sql, new MySqlParameter("@id", 16));
                    DataTable table = dataset.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        string a = (string)row["name"];
                        Console.WriteLine(a.GetType());//查看可以查看类型
                        Console.WriteLine(a);
                    }
                    Console.ReadLine();
                }

                */



    }

}