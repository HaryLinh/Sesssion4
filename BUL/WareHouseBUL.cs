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
    public class WareHouseBUL
    {
        public void GetAllWareHouse(ComboBox combo)
        {
            combo.DataSource = new WareHouseDAL().GetAllWareHouse();
        }
        public void GetAllSourceOrder(ComboBox combo)
        {
            combo.DataSource = new WareHouseDAL().GetAllSourceOrder();
        }
    }
}
