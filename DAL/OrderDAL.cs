using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class OrderDAL
    {
        private static OrderDAL instance;

        internal static OrderDAL Instance
        {
            get 
            {
                if (instance == null)
                    instance = new OrderDAL();
                return instance;
            }
        }
        public bool InserOrder(int SupplyID, int SourceWareHouse, DateTime Date)
        {
            string sql = "Insert into Orders values(1, @SupplyID , @SourceWareHouse , @Desnitaion , @Date )";
            return Utility.ExecuteNonQuery(sql, new object[] { SupplyID, SupplyID, SourceWareHouse, Date });
        }
        public bool InserOrderMaWareHouse(int SupplyID, int SourceWareHouse, DateTime Date)
        {
            string sql = "Insert into Orders values(2, @SupplyID , @SourceWareHouse , @Desnitaion , @Date )";
            return Utility.ExecuteNonQuery(sql, new object[] { SupplyID, SupplyID, SourceWareHouse, Date });
        }
        public int GetOrderID()
        {
            return Utility.GetIDMax();
        }
        public bool UpdateOrder(int OrderID, int TranID, int Source, int Desnitaion, DateTime Date)
        {
            string sql = "Update Orders set TranSactionID = @TranID , SourceWareHouse = @Source , Destination = @Destination , OrderDate = @Date where ID = @OrderID ";
            return Utility.ExecuteNonQuery(sql, new object[] { TranID, Source, Desnitaion, Date, OrderID });
        }
    }
}
