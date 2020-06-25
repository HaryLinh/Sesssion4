using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderItemDAL
    {
        public bool InsertOrderItem(int OrderID, int PartID, string BatchNumber, double Amount)
        {
            string sql = "Insert into OrderItems values( @OrderID , @PartID , @BatchNumber , @Amount )";
            bool c = Utility.ExecuteNonQuery(sql, new object[] { OrderID, PartID, BatchNumber, Amount });
            return c;
        }
        public DataTable GetAllItems(int first, int last)
        {
        
            //string sql = "select  p.PartName, e.TranSactionName , e.OrderDate, e.Amount,  e.source, e.Desnitaion, e.OrderItem  from (select  o.source,  o.Desnitaion , o.TranSactionName , o.OrderDate, od.ID as 'OrderItem', od.PartID,  od.Amount from (select c.ID, c.source,  c.Desnitaion , t.TranSactionName , c.OrderDate from (select a.ID ,a.Source, a.TranSactionID, a.OrderDate, b.Desnitaion from (select o.ID, w.WareHouseName as 'Source',o.TranSactionID, o.OrderDate from Orders o inner join WareHouses w on o.SourceWareHouse = w.ID) AS a inner join (select o.ID, w.WareHouseName as 'Desnitaion', o.TranSactionID, o.OrderDate from Orders o inner join WareHouses w on o.Destination = w.ID) AS b on a.ID = b.ID) AS c inner join TranSactionTypes t on c.TranSactionID = t.ID) AS o inner join OrderItems od on o.ID = od.OrderID) AS e inner join PARTS p on e.PartID = p.ID";
            string sql = "select e.OrderItem,e.PartID,e.IDDes, e.IDSource,e.TranID, p.PartName, e.TranSactionName , e.OrderDate, e.Amount,  e.source, e.Desnitaion from (select  o.source,  o.Desnitaion , o.TranSactionName , o.OrderDate, od.ID as 'OrderItem', od.PartID,  od.Amount, o.IDSource,o.IDDes,o.TranID	from (select c.IDSource , c.source,  c.Desnitaion , t.TranSactionName, t.ID as 'TranID' , c.OrderDate, c.IDDes	from (select a.IDSource ,a.Source, a.TranSactionID, a.OrderDate, b.Desnitaion, b.IDDes	from (select o.ID as 'IDSource', w.WareHouseName as 'Source',o.TranSactionID, o.OrderDate	from Orders o inner join WareHouses w on o.SourceWareHouse = w.ID) a inner join (select o.ID as 'IDDes', w.WareHouseName as 'Desnitaion', o.TranSactionID, o.OrderDate	from Orders o left join WareHouses w on o.Destination = w.ID) b on a.IDSource = b.IDDes)  c left join TranSactionTypes t on c.TranSactionID = t.ID) o	left join OrderItems od on o.IDSource = od.OrderID) e inner join PARTS p on e.PartID = p.ID order by e.OrderItem DESC offset @first rows fetch next @last rows only";
            return Utility.ExecuteDataReader(sql, new object[] { first, last});

        }
        public DataTable GetLastRow()
        {
            string sql = "select top(13) e.OrderItem,e.PartID,e.IDDes, e.IDSource,e.TranID, p.PartName, e.TranSactionName , e.OrderDate, e.Amount,  e.source, e.Desnitaion from (select  o.source,  o.Desnitaion , o.TranSactionName , o.OrderDate, od.ID as 'OrderItem', od.PartID,  od.Amount, o.IDSource,o.IDDes,o.TranID	from (select c.IDSource , c.source,  c.Desnitaion , t.TranSactionName, t.ID as 'TranID' , c.OrderDate, c.IDDes	from (select a.IDSource ,a.Source, a.TranSactionID, a.OrderDate, b.Desnitaion, b.IDDes	from (select o.ID as 'IDSource', w.WareHouseName as 'Source',o.TranSactionID, o.OrderDate	from Orders o inner join WareHouses w on o.SourceWareHouse = w.ID) a inner join (select o.ID as 'IDDes', w.WareHouseName as 'Desnitaion', o.TranSactionID, o.OrderDate	from Orders o left join WareHouses w on o.Destination = w.ID) b on a.IDSource = b.IDDes)  c left join TranSactionTypes t on c.TranSactionID = t.ID) o	left join OrderItems od on o.IDSource = od.OrderID) e inner join PARTS p on e.PartID = p.ID order by e.OrderItem desc";
            return Utility.ExecuteDataReader(sql);
        }
        public bool DeleteOrderItem(int ID)
        {
            string sql = "Delete from OrderItems where ID = @ID ";
            return Utility.ExecuteNonQuery(sql, new object[] { ID });
        }
        public bool UpdateOrderItems(int PartID, int Amount, int OrderItemID)
        {
            string sql = "Update OrderItems set PartID = @PartID , Amount = @Amount where ID = @OrderItemID ";
            return Utility.ExecuteNonQuery(sql, new object[] { PartID , Amount, OrderItemID });
        }
        public DataTable GetBathByPart(int PartID)
        {
            string sql = "select p.ID, p.PartName, o.BathNumber  from PARTS p inner join OrderItems o on p.ID = o.PartID where p.ID = @PartID";
            return Utility.ExecuteDataReader(sql, new object[] { PartID});
        }
        public DataTable GetByPartAndBath(int PartID, string Bath)
        {
            string sql = "select o.ID, o.OrderID, o.PartID, o.BathNumber, o.Amount from OrderItems o inner join Orders od on o.OrderID = od.ID where o.PartID = @PartID and o.BathNumber = @Batch ";
            return Utility.ExecuteDataReader(sql, new object[] { PartID, Bath });
        }
        public bool UpdateAmount(double  Amount, int OrderItemID)
        {
            string sql = "Update OrderItems set Amount = @Amount where ID = @OrderItemID";
            return Utility.ExecuteNonQuery(sql, new object[] { Amount, OrderItemID });
        }
    }
}
