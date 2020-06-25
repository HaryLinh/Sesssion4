using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Utility
    {
        public static string StringConnect = @"Data Source=DESKTOP-IKP0EDP;Initial Catalog=Session4;Integrated Security=True";
        public static DataTable ExecuteDataReader(string sql, object[] param = null)
        {
            SqlConnection conn = new SqlConnection(StringConnect);
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            if(param != null)
            {
                int i = 0;
                string[] listitem = sql.Split(' ');
                foreach(string item in listitem)
                {
                    if (item.Contains("@"))
                    {
                        sqlCommand.Parameters.AddWithValue(item, param[i]);
                        i++;
                    }
                }
            }
            SqlDataReader sqlDataReader;
            DataTable dataTable = new DataTable();
            try
            {
                sqlDataReader = sqlCommand.ExecuteReader();
    
                dataTable.Load(sqlDataReader);
            }
            catch(Exception e)
            {

            }
            conn.Close();
            return dataTable;
        }
        public static bool ExecuteNonQuery(String sql, object[] param = null)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(StringConnect);
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            if (param != null)
            {
                int i = 0;
                string[] listitem = sql.Split(' ');
                foreach (string item in listitem)
                {
                    if (item.Contains("@"))
                    {
                        sqlCommand.Parameters.AddWithValue(item, param[i]);
                        i++;
                    }
                }
            }
            try
            {
                sqlCommand.ExecuteNonQuery();
                check = true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                conn.Close();
            }
            return check;
        }
        public static int GetIDMax()
        {
            int ID = 0;
            string sql = "SELECT MAX(id) FROM Orders";
            SqlConnection conn = new SqlConnection(StringConnect);
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            ID = int.Parse(sqlCommand.ExecuteScalar().ToString());
            conn.Close();
            return ID;
        }
    }
}
