using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;

namespace Session4
{
    public partial class ViewBatch : Form
    {
        public ViewBatch()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ViewBatch_Load(object sender, EventArgs e)
        {
            List<object> listParams = new List<object>();
            listParams = (List<object>)Application.OpenForms["frmIventoryReport"].Tag;
            string PartName = listParams[1].ToString();
            int WareHouse = (int)(listParams[0]);
            new ReportBUL().GetBatchNumber(ref dataGridView1, WareHouse, PartName);

        }
    }
}
