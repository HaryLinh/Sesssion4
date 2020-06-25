using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace BUL
{
    public class ReportBUL
    {
        public void GetAllReports(ref DataGridView data, int WareHouse)
        {
            data.DataSource = new ReportDAL().GetAllReports(WareHouse);
        }
        public void GetOutOfStock(ref DataGridView data, int WareHouse)
        {
            data.DataSource = new ReportDAL().GetOutOfStock(WareHouse);
        }
        public void GetCurrentStock(ref DataGridView data, int WareHouse)
        {
            data.DataSource = new ReportDAL().GetCurrentStock(WareHouse);
        }
        public void GetBatchNumber(ref DataGridView data, int Ware_House, string PartName)
        {
            data.DataSource = new ReportDAL().GetBatchNumber(Ware_House, PartName);
        }
    }
}
