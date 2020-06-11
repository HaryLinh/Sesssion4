using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace DAL
{
    public class WareHouseDAL
    {
        public List<WareHouse> GetAllWareHouse()
        {
            List<WareHouse> ListWareHouses = new List<WareHouse>();
            string SqlWareHouse = "Select * from WareHouses";
            DataTable data =  Utility.ExecuteDataReader(SqlWareHouse);
            foreach(DataRow row in data.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                string WareHouseName = row["WareHouseName"].ToString();
                WareHouse wareHouse = new WareHouse(ID, WareHouseName, null);
                ListWareHouses.Add(wareHouse);
            }
            return ListWareHouses;
        }
        public List<WareHouse> GetAllSourceOrder()
        {
            string sql = "select DISTINCT  w.ID, w.WareHouseName from WareHouses w  inner join Orders o on w.ID = o.Destination";
            List<WareHouse> ListWareHouses = new List<WareHouse>();
            DataTable data = Utility.ExecuteDataReader(sql);
            foreach (DataRow row in data.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                string WareHouseName = row["WareHouseName"].ToString();
                WareHouse wareHouse = new WareHouse(ID, WareHouseName, null);
                ListWareHouses.Add(wareHouse);
            }
            return ListWareHouses;
        }
    }
}
