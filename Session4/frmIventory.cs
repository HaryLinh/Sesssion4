using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
namespace Session4
{
    public partial class frmIventory : Form
    {
        OrderItemBUL orderItemBUL = new OrderItemBUL();
        DataTable data = new DataTable();
        int first = 0;
        int last = 13;
        public frmIventory()
        {
            InitializeComponent();
            CheckPagination();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmIventory_Load(object sender, EventArgs e)
        {
            LoadAction();
            orderItemBUL.GetAllOrderItem(dataGridView1, 0, 13);
        }
        public void LoadAction()
        {
          
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            DataGridViewButtonColumn button2 = new DataGridViewButtonColumn();
            {
                button.Name = "delete";
                button.HeaderText = "Action";
                button.Text = "Delete";
                button.UseColumnTextForButtonValue = true;
                button2.Name = "edit";
                button2.HeaderText = "";
                button2.Text = "Edit";
                button2.UseColumnTextForButtonValue = true;
                button.Width = 50;
                button2.Width = 50;
                this.dataGridView1.Columns.Add(button2);
                this.dataGridView1.Columns.Add(button);

            }
   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["delete"].Index && e.RowIndex >= 0)
            {
                int ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                bool check = orderItemBUL.DeleteOrderItem(ID);
                if (check)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    MessageBox.Show("Xoa thanh cong");
                }
                else
                {
                    MessageBox.Show("Xoa that bai");
                }

            }else if (e.ColumnIndex == dataGridView1.Columns["edit"].Index && e.RowIndex >= 0)
            {
                int IDSource = -1;
                string PartName = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                string TranSaction = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                DateTime Date = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString());
                int Amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString());
                string Source = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                string Desnitaion = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                int OrderItem = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                int PartID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                int IDDes = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() != null)
                {
                    IDSource = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                }
                int TranID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                List<object> listParams = new List<object>{ PartName, TranSaction, Date, Amount, Source, Desnitaion, OrderItem, PartID, IDDes,IDSource, TranID};
                this.Tag = listParams;
                frmEditIventory edit = new frmEditIventory();
                edit.ShowDialog();
                orderItemBUL.GetAllOrderItem(dataGridView1, 0, 13);
            }
        
        }

        private void first_page_Click(object sender, EventArgs e)
        {
            orderItemBUL.GetAllOrderItem(dataGridView1, 0, 13);
        }

        private void last_page_Click(object sender, EventArgs e)
        {
            orderItemBUL.GetLastRow(dataGridView1);
        }

        private void next_Click(object sender, EventArgs e)
        {
            first += 13;
            last += 13;
            orderItemBUL.GetAllOrderItem(dataGridView1, first, last);
            CheckPagination();
        }

        private void pre_Click(object sender, EventArgs e)
        {
            first -= 13;
            last -= 13;
            orderItemBUL.GetAllOrderItem(dataGridView1, first, last);
            CheckPagination();
        }
        
        private void CheckPagination()
        {
            if (first == 0)
                pre.Enabled = false;
            else
                pre.Enabled = true;
        }

        private void warehouseManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWarehouse warehouse = new frmWarehouse();
            warehouse.ShowDialog();
            StartPosition = FormStartPosition.CenterScreen;
            orderItemBUL.GetAllOrderItem(dataGridView1, 0, 13);

        }

        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIventoryReport purchase = new frmIventoryReport();
            purchase.ShowDialog();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void purchaseOrderManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase purchase = new frmPurchase();
            purchase.ShowDialog();
            StartPosition = FormStartPosition.CenterScreen;
            orderItemBUL.GetAllOrderItem(dataGridView1, 0, 13);
        }
    }

}
