using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace EQIS
{
    class DBUtils
    {
        public static MySqlConnection getConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            MySqlConnection con = null;
            con = new MySqlConnection(connStr);
            con.Open();
            return con;
        }

        //插入语句预编译
        //mySqlCommand.CommandText = "insert into user(id, name, password) values(@id, @name, @password)"
        //mySqlCommand.Parameters.AddWithValue(@id, int.Parse("1"));
        //mySqlCommand.Parameters.AddWithValue(@name, "nnnn");
        //mySqlCommand.Parameters.AddWithValue(@password, "1234");
        //mySqlCommand.ExecuteNonQuery();
        public static void test()
        {
            MySqlConnection con = getConnection();
            MySqlCommand mySqlCommand = con.CreateCommand();
            mySqlCommand.CommandText = "SELECT * FROM user WHERE id = ?1 and name = ?2";
            mySqlCommand.Parameters.AddWithValue("?1", 1);
            mySqlCommand.Parameters.AddWithValue("?2", "sys1");
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine(reader.GetString(0) + reader.GetString(1) + reader.GetString(2) + reader.GetString(3));
                    }
                }
            }
            catch (Exception)
            { 
                    Console.WriteLine("查询失败了!");
            }
            finally
            { 
                reader.Close();
                close(con);
            }
        }
        public static void close(MySqlConnection msc)
        {
            if (msc != null)
            {
                msc.Close();
            }
        }
    }
}
