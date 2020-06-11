using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUL
{
    public class OrderBUL
    {
        public bool InserOrder(int SupplyID, int SourceWareHouse, DateTime Date)
        {
            return new OrderDAL().InserOrder(SupplyID, SourceWareHouse, Date);
        }

        public bool InserOrderMaWareHouse(int SupplyID, int SourceWareHouse, DateTime Date)
        {
            return new OrderDAL().InserOrderMaWareHouse(SupplyID, SourceWareHouse, Date);
        }
        public int GetOrderID()
        {
            return new OrderDAL().GetOrderID();
        }
        public bool UpdateOrder(int OrderID, int TranID, int Source, int Desnitaion, DateTime Date)
        {
            return new OrderDAL().UpdateOrder(OrderID, TranID, Source, Desnitaion, Date);
        }
    }
}
