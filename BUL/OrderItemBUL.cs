using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace BUL
{
    public class OrderItemBUL
    {
        public bool InsertOrderItem(int OrderID, int PartID, string BatchNumber, double Amount)
        {
            return new OrderItemDAL().InsertOrderItem(OrderID, PartID, BatchNumber, Amount);
        }
        public void GetAllOrderItem(DataGridView data, int first, int last)
        {
            data.DataSource = new OrderItemDAL().GetAllItems(first, last);
        }
        public void GetLastRow(DataGridView data)
        {
            data.DataSource  =  new OrderItemDAL().GetLastRow();
        }
        public bool DeleteOrderItem(int ID)
        {

            return new OrderItemDAL().DeleteOrderItem(ID);
        }
        public bool UpdateOrderItems(int PartID, int Amount, int OrderItemID)
        {
            return new OrderItemDAL().UpdateOrderItems(PartID, Amount, OrderItemID);
        }
        public void GetBathByPart(ComboBox combo, int PartID)
        {
            combo.DataSource = new OrderItemDAL().GetBathByPart(PartID);
        }
        public void GetByPartAndBath( ref DataTable data ,int PartID, string Bath)
        {
            data = new OrderItemDAL().GetByPartAndBath(PartID, Bath);
        }
        public bool UpdateAmount(double Amount, int OrderItemID)
        {
            return new OrderItemDAL().UpdateAmount(Amount, OrderItemID);
        }
    }
}
