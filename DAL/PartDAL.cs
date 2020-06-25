using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PartDAL
    {
        public List<Part> GetAllParts()
        {
            List<Part> ListParts = new List<Part>();
            string sql = "Select * from PARTS";
            DataTable data = Utility.ExecuteDataReader(sql);
            foreach (DataRow row in data.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                string PartName = row["PartName"].ToString();
                string EffectiveLife = row["EffectiveLife"].ToString();
                bool BatchNumberHasRequired = bool.Parse(row["BatchNumberHasRequired"].ToString());
                int MinimumAmount = int.Parse(row["MinimumAmount"].ToString());
                Part part = new Part(ID, PartName, EffectiveLife, BatchNumberHasRequired, MinimumAmount,  null);
                ListParts.Add(part);
            }
            return ListParts;
        }
        
        public bool UpdateAmount (double Amount, int ID)
        {
            string sql = "Update PARTS SET MinimumAmount = @MinimumAmount where ID = @ID";
            return Utility.ExecuteNonQuery(sql, new object[] { Amount, ID});
        }
        public Part GetPartByID (int PartID)
        {
            Part part = new Part();
            string sql = "Select * from PARTS where ID = @PartID";
            DataTable data = Utility.ExecuteDataReader(sql, new object[] { PartID});
            foreach (DataRow row in data.Rows)
            {
                int ID = int.Parse(row["ID"].ToString());
                string PartName = row["PartName"].ToString();
                string EffectiveLife = row["EffectiveLife"].ToString();
                bool BatchNumberHasRequired = bool.Parse(row["BatchNumberHasRequired"].ToString());
                int MinimumAmount = int.Parse(row["MinimumAmount"].ToString());
                part = new Part(ID, PartName, EffectiveLife, BatchNumberHasRequired, MinimumAmount, null);
            }
            return part;
        }
        public bool CheckHasRequire(int PartID)
        {
            bool check = false;
            List<Part> ListParts = GetAllParts();
            foreach(Part part in ListParts)
            {
                if(part.ID == PartID)
                {
                    check = part.BathNumber;
                    break;
                }
            }
            return check;
        }
        public int GetAmountByID(int ID)
        {
            Part part = GetPartByID(ID);
            return part.MiniumAmount;
        }
        
        public DataTable GetPartBySource(int WareHouseSource)
        {
            string sql = "select DISTINCT PartID as ID, PartName from OrderItems inner join PARTS  on OrderItems.PartID = PARTS.ID inner join Orders on Orders.ID = OrderItems.OrderID where Orders.Destination = @Source ";
            DataTable data = Utility.ExecuteDataReader(sql, new object[] { WareHouseSource });
            return data;
        }
    }
}
