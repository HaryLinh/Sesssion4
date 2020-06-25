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
    public partial class frmIventoryReport : Form
    {
        WareHouseBUL wareHouseBUL = new WareHouseBUL();
        ReportBUL report = new ReportBUL();
        public frmIventoryReport()
        {
            InitializeComponent();
            LoadAction();
        }

        private void frmIventoryReport_Load(object sender, EventArgs e)
        {
            LoadDataCboSourceWare();
  

        }
        public void LoadDataCboSourceWare()
        {
            wareHouseBUL.GetAllSourceOrder(cbbSource);
            cbbSource.DisplayMember = "WareHouseNam";
            cbbSource.ValueMember = "ID";
            cbbSource.SelectedItem = null;
            cbbSource.SelectedText = "Please, choose a warehouse....";
        }
        public void LoadAction()
        {
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "view";
                button.HeaderText = "viewbatch";
                button.Text = "viewbatch";
                button.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(button);
            }
        }

        private void cbbSource_SelectionChangeCommitted(object sender, EventArgs e)
        {
            report.GetAllReports(ref dataGridView1, (int)(cbbSource.SelectedValue));
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(cbbSource.SelectedIndex < 0)
            {
                MessageBox.Show("Hey, Please choose a warehouse");
                radioButton1.Checked = false;
            }
            else
            {
                report.GetCurrentStock(ref dataGridView1, (int)(cbbSource.SelectedValue));
                dataGridView1.Columns["view"].Visible = true;
            }
        }

        private void radioButton1_AppearanceChanged(object sender, EventArgs e)
        {
            if (cbbSource.SelectedIndex < 0)
            {
                MessageBox.Show("Hey, Please choose a warehouse");
                radioButton1.Checked = false;
            }
            else
            {
                report.GetCurrentStock(ref dataGridView1, (int)(cbbSource.SelectedValue));
                dataGridView1.Columns["view"].Visible = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbSource.SelectedIndex < 0)
            {
                MessageBox.Show("Hey, Please choose a warehouse");
                radioButton2.Checked = false;
            }
            else
            {
                report.GetAllReports(ref dataGridView1, (int)(cbbSource.SelectedValue));
                dataGridView1.Columns["view"].Visible = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbbSource.SelectedIndex < 0)
            {
                MessageBox.Show("Hey, Please choose a warehouse");
                radioButton3.Checked = false;
            }
            else
            {
                report.GetOutOfStock(ref dataGridView1, (int)(cbbSource.SelectedValue));
                dataGridView1.Columns["view"].Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (e.ColumnIndex == dataGridView1.Columns["view"].Index && e.RowIndex >= 0)
            {
                this.Tag = new List<Object>() { (int)cbbSource.SelectedValue, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()};
                ViewBatch view = new ViewBatch();
                view.ShowDialog();
            }
        }
    }
}
