using DTO;
using Session4;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class SupplyDAL
    {
        private static SupplyDAL instance;
        public static SupplyDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new SupplyDAL();
                return instance;
            }
        }
        public List<Supply> GetAllSupplies()
        {
            List<Supply> ListSupplies = new List<Supply>();
            string SqlWareHouse = "Select * from Suppliers";
            DataTable data = Utility.ExecuteDataReader(SqlWareHouse);
            foreach (DataRow row in data.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                string WareHouseName = row["SupplyName"].ToString();
                Supply supply = new Supply(ID, WareHouseName, null);
                ListSupplies.Add(supply);
            }
            return ListSupplies;
        }

        public SupplyDAL()
        {

        }

    }
}
