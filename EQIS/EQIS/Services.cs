using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace EQIS
{
    class Services
    {
        public Dictionary<String, String> login(String name, String password)
        {
            MySqlConnection con = DBUtils.getConnection();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT ID,NAME,PASSWORD,CHARA FROM USER WHERE NAME = ?1 AND PASSWORD = ?2";
            cmd.Parameters.AddWithValue("?1", name);
            cmd.Parameters.AddWithValue("?2", password);
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    Dictionary<String, String> dir = new Dictionary<string, string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dir.Add(reader.GetName(i).ToLower(), reader.GetValue(i).ToString());
                    }
                    return dir;
                }
            }
            catch
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                DBUtils.close(con);
                reader.Close();
            }
            return null;
        }
        /**
         * 查询所有的用户
         */
        public List<Dictionary<String, String>> queryAllu()
        {
            MySqlConnection con = DBUtils.getConnection();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM USER";
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                List<Dictionary<String, String>> list = new List<Dictionary<String, String>>();
                while (reader.Read())
                {
                    Dictionary<String, String> dir = new Dictionary<string, string>();
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        dir.Add(reader.GetName(i).ToLower(), reader.GetValue(i).ToString());
                    }
                    list.Add(dir);
                }
                return list;
            }
            catch
            { }
            finally
            {
                DBUtils.close(con);
                reader.Close();
            }
            return new List<Dictionary<String, String>>();
        }
        /**
         * 查询所有的机器
         */
        public List<Dictionary<String, String>> queryAllm()
        {
            MySqlConnection con = DBUtils.getConnection();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM MACHINE ORDER BY ID";
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                List<Dictionary<String, String>> list = new List<Dictionary<String, String>>();
                while (reader.Read())
                {
                    Dictionary<String, String> dir = new Dictionary<string, string>();
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        dir.Add(reader.GetName(i).ToLower(), reader.GetValue(i).ToString());
                    }
                    list.Add(dir);
                }
                return list;
            }
            catch
            { }
            finally
            {
                DBUtils.close(con);
                reader.Close();
            }
            return new List<Dictionary<String, String>>();
        }

        /**
         * 权限管理
         */
        public List<String> queryGrand(int id)
        {
            MySqlConnection con = DBUtils.getConnection();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT A.NAME FROM MACHINE A, NYMACHINE B WHERE A.ID = B.MID AND B.UID = ?1 AND A.USERING = '1'";
            cmd.Parameters.AddWithValue("?1", id);
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                List<String> list = new List<String>();
                while(reader.Read())
                {
                    list.Add(reader.GetValue(0).ToString());
                }
                return list;
            }
            catch
            {}
            finally
            {
                DBUtils.close(con);
                reader.Close();
            }
            return null;
        }
        public static bool insert(int mid, String dt, DataModel dm)
        {
            MySqlConnection con = DBUtils.getConnection();
            try
            {
                String str = ObjectStringSwap.bytes2String(dm.Bs);
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into datas(mid, dataval, gt) values(?1, ?2, ?3)";
                cmd.Parameters.AddWithValue("?1", mid);
                cmd.Parameters.AddWithValue("?2", str);
                cmd.Parameters.AddWithValue("?3", dt);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("*" + e.StackTrace);
            }
            finally
            {
                DBUtils.close(con);    
            }
            return false;
        }
        /*查询数据
         * uid : 使用者id
         * sdt : 起始时间
         * edt : 结束时间
         * return : Dictionary<dt, val>
         */
        public List<Dictionary<String, String>> queryData(int uid, String sdt, String edt)
        {
            MySqlConnection con = DBUtils.getConnection();
            MySqlDataReader dr = null;
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT C.NAME, A.DATAVAL, A.GT FROM DATAS A, USER B, MACHINE C, NYMACHINE D" +
                                    " WHERE B.ID=D.UID AND D.MID=C.ID AND C.ID=A.MID AND B.ID=?1 AND A.GT >= ?2 AND A.GT <= ?3";
                cmd.Parameters.AddWithValue("?1", uid);
                cmd.Parameters.AddWithValue("?2", sdt);
                cmd.Parameters.AddWithValue("?3", edt);
                
                if (cmd.ExecuteScalar() != null)
                {
                    List<Dictionary<String, String>> list = new List<Dictionary<string, string>>();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Dictionary<String, String> dir = new Dictionary<string, string>();
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            dir.Add(dr.GetName(i).ToLower(), dr.GetValue(i).ToString());
                        }
                        list.Add(dir);
                    }
                    return list;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                DBUtils.close(con);
            }
            return null;
        }

        //删除用户
        public Boolean delUserById(String id)
        {
            MySqlConnection con = DBUtils.getConnection();
            try
            {
                MySqlCommand cmd1 = con.CreateCommand();
                MySqlCommand cmd2 = con.CreateCommand();
                cmd1.CommandText = "delete from nymachine where uid = ?1";
                cmd1.Parameters.AddWithValue("?1", id);
                cmd1.ExecuteNonQuery();
                cmd2.CommandText = "delete from user where id = ?1";
                cmd2.Parameters.AddWithValue("?1", id);
                return cmd2.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("*" + e.StackTrace);
            }
            finally
            {
                DBUtils.close(con);
            }
            return false;
        }
        //修改区域状态
        public Boolean updateMachineById(String id, String usering)
        {
            MySqlConnection con = DBUtils.getConnection();
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "update machine set usering = ?1 where id = ?2";
                cmd.Parameters.AddWithValue("?1", usering);
                cmd.Parameters.AddWithValue("?2", id);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("*" + e.StackTrace);
            }
            finally
            {
                DBUtils.close(con);
            }
            return false;
        }

        //添加用户
        public Boolean addUser(String name, String password)
        {
            MySqlConnection con = DBUtils.getConnection();
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into user(name, password, chara) values(?1, ?2, '2')";
                cmd.Parameters.AddWithValue("?1", name);
                cmd.Parameters.AddWithValue("?2", password);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("*" + e.StackTrace);
            }
            finally
            {
                DBUtils.close(con);
            }
            return false;
        }
        //检查用户
        public Boolean UserIsExisted(String name)
        {
            MySqlConnection con = DBUtils.getConnection();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT ID,NAME,PASSWORD,CHARA FROM USER WHERE NAME = ?1";
            cmd.Parameters.AddWithValue("?1", name);
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                DBUtils.close(con);
                reader.Close();
            }
            return false;
        }

        //添加管理区域
        public Boolean addManageArea(String uid, String mid)
        {
            MySqlConnection con = DBUtils.getConnection();
            Console.WriteLine(uid + " " + mid);
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "insert into nymachine(uid, mid) values(?1, ?2)";
                cmd.Parameters.AddWithValue("?1", uid);
                cmd.Parameters.AddWithValue("?2", mid);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("*" + e.StackTrace);
            }
            finally
            {
                DBUtils.close(con);
            }
            return false;
        }
        //删除管理区域
        public Boolean delManageArea(String uid, String mid)
        {
            Console.WriteLine(uid + " " + mid);
            MySqlConnection con = DBUtils.getConnection();
            try
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "delete from nymachine where uid = ?1 and mid = ?2";
                cmd.Parameters.AddWithValue("?1", uid);
                cmd.Parameters.AddWithValue("?2", mid);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("*" + e.StackTrace);
            }
            finally
            {
                DBUtils.close(con);
            }
            return false;
        }
        //监管机器
        public Boolean Listening(String uid, String mid)
        {
            MySqlConnection con = DBUtils.getConnection();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT A.UID, A.MID FROM NYMACHINE A WHERE A.UID = ?1 AND A.MID = ?2";
            cmd.Parameters.AddWithValue("?1", uid);
            cmd.Parameters.AddWithValue("?2", mid);
            MySqlDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                DBUtils.close(con);
                reader.Close();
            }
            return false;
        }
    }
}
