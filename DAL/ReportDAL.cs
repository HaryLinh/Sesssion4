using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReportDAL
    {
        public DataTable GetAllReports(int Ware_House)
        {
            DataTable data = new DataTable();
            string sql = "select DISTINCT t.PartName, t.Recevied - ISNULL(h.Ban, 0 ) as 'CurrentStock', t.Recevied from ( select PARTS.PartName, sum(Amount) as 'Recevied' from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID  inner join Orders on Orders.ID = OrderItems.OrderID where Orders.Destination = @Ware group by PARTS.PartName) t full join ( select PARTS.PartName, sum(Amount) as 'Ban'  from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID  inner join Orders on Orders.ID = OrderItems.OrderID where Orders.SourceWareHouse = @WareHouse and Orders.TranSactionID = 2 group by PARTS.PartName) h  on t.PartName = h.PartName";
            data = Utility.ExecuteDataReader(sql, new object[] { Ware_House, Ware_House });
            return data;

        }
        public DataTable GetOutOfStock(int Ware_House)
        {
            DataTable data = new DataTable();
            string sql = "select * from ( select DISTINCT t.PartName, t.Recevied - ISNULL(h.Ban, 0 ) as 'CurrentStock', t.Recevied from ( select PARTS.PartName, sum(Amount) as 'Recevied' from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID  inner join Orders on Orders.ID = OrderItems.OrderID where Orders.Destination = @Ware group by PARTS.PartName) t full join ( select PARTS.PartName, sum(Amount) as 'Ban'  from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID  inner join Orders on Orders.ID = OrderItems.OrderID where Orders.SourceWareHouse = @WareHouse and Orders.TranSactionID = 2 group by PARTS.PartName) h  on t.PartName = h.PartName) r where r.CurrentStock <  0";
            data = Utility.ExecuteDataReader(sql, new object[] { Ware_House, Ware_House });
            return data;

        }
        public DataTable GetCurrentStock(int Ware_House)
        {
            DataTable data = new DataTable();
            string sql = "select * from ( select DISTINCT t.PartName, t.Recevied - ISNULL(h.Ban, 0 ) as 'CurrentStock', t.Recevied from ( select PARTS.PartName, sum(Amount) as 'Recevied' from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID  inner join Orders on Orders.ID = OrderItems.OrderID where Orders.Destination = @Ware group by PARTS.PartName) t full join ( select PARTS.PartName, sum(Amount) as 'Ban'  from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID  inner join Orders on Orders.ID = OrderItems.OrderID where Orders.SourceWareHouse = @WareHouse and Orders.TranSactionID = 2 group by PARTS.PartName) h  on t.PartName = h.PartName) r where r.CurrentStock > 0";
            data = Utility.ExecuteDataReader(sql, new object[] { Ware_House, Ware_House });
            return data;

        }
        public DataTable GetBatchNumber(int Ware_House, string PartName)
        {
            DataTable data = new DataTable();
            string sql = "select * from (select DISTINCT t.PartName, t.Recevied - ISNULL(h.Ban, 0 ) as 'CurrentStock', t.Recevied ,t.BathNumber from ( select PARTS.PartName,OrderItems.BathNumber , sum(Amount) as 'Recevied' from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID  inner join Orders on Orders.ID = OrderItems.OrderID where Orders.Destination = @Ware group by PARTS.PartName, OrderItems.BathNumber) t full join ( select PARTS.PartName, OrderItems.BathNumber, sum(Amount) as 'Ban'  from OrderItems inner join PARTS on OrderItems.PartID = PARTS.ID  inner join Orders on Orders.ID = OrderItems.OrderID where Orders.SourceWareHouse = @WareHouse and Orders.TranSactionID = 2 group by PARTS.PartName, OrderItems.BathNumber) h  on t.PartName = h.PartName) l where l.PartName = @PartName ";
            data = Utility.ExecuteDataReader(sql, new object[] { Ware_House, Ware_House, PartName });
            return data;

        }
    }
}
