using System;
using System.Collections;
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
    public partial class frmWarehouse : Form
    {
        SupplyBUL supplyBUL = new SupplyBUL();
        WareHouseBUL wareHouseBUL = new WareHouseBUL();
        PartBUL partBUL = new PartBUL();
        OrderBUL orderBUL = new OrderBUL();
        OrderItemBUL orderItemBUL = new OrderItemBUL();
        DataTable data;
       
        public frmWarehouse()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            data = InitTable();
        }

        private void frmWarehouse_Load(object sender, EventArgs e)
        {
            LoadDataCboDes();
            LoadDataCboSourceWare();
            LoadAction();
            data.Columns[3].ColumnMapping = MappingType.Hidden;
            data.Columns[4].ColumnMapping = MappingType.Hidden;
            data.Columns[5].ColumnMapping = MappingType.Hidden;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable OrderByPartBath = new DataTable();
            orderItemBUL.GetByPartAndBath(ref OrderByPartBath, (int)cboPartName.SelectedValue, cbbBatch.Text);
            DataRow row = OrderByPartBath.Rows[0];
            int OrderItemID = int.Parse(row["ID"].ToString());
            int OrderID = int.Parse(row["OrderID"].ToString());
            int PartID = int.Parse(row["PartID"].ToString());
            string BathNumber = row["BathNumber"].ToString();
            int TotalAmount = int.Parse(row["Amount"].ToString());
            if (cboPartName.SelectedIndex < 0 || txtAmount.Text == "")
            {
                MessageBox.Show("Please choose and fill information and amount is a number");
            }
            else
            {
                string exp = "PartName = '" + cboPartName.Text + "' AND BatchNumber = '" + cbbBatch.Text + "'";
                int ID = int.Parse(cboPartName.SelectedValue.ToString());
                double Amount = double.Parse(txtAmount.Text.ToString());
                bool checkPartRequire = partBUL.CheckHasRequire(ID);
                if (checkPartRequire && cbbBatch.SelectedIndex == -1)
                {
                    MessageBox.Show("Please enter batchnumber");
                }
                else
                {
                    DataRow[] dr = null;
                    try
                    {
                        dr = data.Select(exp);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    if (dr.Length == 0)
                    {
                        if (CheckAmount(Amount, TotalAmount))
                        {
                            data.Rows.Add(cboPartName.Text, checkPartRequire ? cbbBatch.Text : "", txtAmount.Text, OrderItemID, ID , TotalAmount);
                            dataGird.DataSource = data;
                        }
                        else
                        {
                            MessageBox.Show("Sorry,Out of stock !!");
                        }
                    }
                    else
                    {
                        int index = data.Rows.IndexOf(dr[0]);
                        int SumAmount = int.Parse(data.Rows[index]["Amount"].ToString()) + int.Parse(txtAmount.Text.ToString());
                        if (CheckAmount(SumAmount, TotalAmount))
                        {
                            data.Rows[index]["Amount"] = int.Parse(data.Rows[index]["Amount"].ToString()) + int.Parse(txtAmount.Text.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Sorry,Out of stock !!");
                        }

                    }
                }
            }
        }
        public void LoadDataCboSourceWare()
        {
            wareHouseBUL.GetAllSourceOrder(cbbSource);
            cbbSource.DisplayMember = "WareHouseNam";
            cbbSource.ValueMember = "ID";
            cbbSource.SelectedItem = null;
            cbbSource.SelectedText = "Please, choose a warehouse....";
        }
        public void LoadDataCboDes()
        {
            wareHouseBUL.GetAllWareHouse(cbbDes);
            cbbDes.DisplayMember = "WareHouseNam";
            cbbDes.ValueMember = "ID";
            cbbDes.SelectedItem = null;
            cbbDes.SelectedText = "Please, choose a warehouse....";
        }
        public void LoadDataCboPart(int Source)
        {
            partBUL.GetPartBySource(cboPartName, Source);
            cboPartName.DisplayMember = "PartName";
            cboPartName.ValueMember = "ID";
            cboPartName.SelectedItem = null;
            cboPartName.SelectedText = "Please, choose a part....";
        }
        private void cbbSource_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDataCboPart((int)cbbSource.SelectedValue);
        }

        private void cbbDes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cbbSource.Text == cbbDes.Text)
            {
                MessageBox.Show("Ohh no!! You can't choose duplicate warehouse!");
                cbbDes.SelectedIndex = -1;
            }
        }
        private DataTable InitTable()
        {
            DataTable data = new DataTable();
            data.Columns.Add("PartName", typeof(string));
            data.Columns.Add("BatchNumber", typeof(string));
            data.Columns.Add("Amount", typeof(double));
            data.Columns.Add("OrderItemID", typeof(int));
            data.Columns.Add("PartID", typeof(int));
            data.Columns.Add("AmountOrigin", typeof(int));
            return data;
        }
        public void LoadAction()
        {
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "delete";
                button.HeaderText = "Action";
                button.Text = "Delete";
                button.UseColumnTextForButtonValue = true;
                this.dataGird.Columns.Add(button);
            }
        }
        private bool ValidateForm()
        {
            bool check = false;
            if (cbbSource.SelectedIndex >= 0 && cbbDes.SelectedIndex >= 0)
                check = true;
            return check;
        }
        private void ClearField()
        {
            cboPartName.SelectedIndex = -1;
            cbbDes.SelectedIndex = -1;
            cbbSource.SelectedIndex = -1;
            cbbBatch.SelectedIndex = -1;
            txtAmount.Text = "";
            data.Clear();
        }
        private bool CheckAmount(double Amount, int TotalAmount)
        {
            bool check = false;
            if (Amount <= TotalAmount)
                check = true;

            return check;
        }
        private void UpdateAmount()
        {
            foreach (DataRow row in data.Rows)
            {
                int OrderItemID = int.Parse(row["OrderItemID"].ToString());
                double Amount = double.Parse(row["Amount"].ToString());
                int AmountOrigin = int.Parse(row["AmountOrigin"].ToString());
                orderItemBUL.UpdateAmount(AmountOrigin - Amount, OrderItemID);
            }
        }

        private bool InsertOrder()
        {
            int Source = int.Parse(cbbSource.SelectedValue.ToString());
            int Des = int.Parse(cbbDes.SelectedValue.ToString());
            DateTime date = DateTime.Parse(dateTimePicker1.Value.ToString());
            return orderBUL.InserOrderMaWareHouse(Source, Des, date);
        }
        private bool InsertAllOrderItem()
        {
            bool check = true;
            int OrderID = orderBUL.GetOrderID();
            foreach (DataRow row in data.Rows)
            {
                int PartID = int.Parse(row["PartID"].ToString());
                string BatchNumber = row["BatchNumber"].ToString();
                double Amount = double.Parse(row["Amount"].ToString());
                try
                {
                    orderItemBUL.InsertOrderItem(OrderID, PartID, BatchNumber, Amount);
                }
                catch (Exception e)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateForm() && data.Rows.Count > 0)
            {
                if (InsertOrder() && InsertAllOrderItem())
                {
                    MessageBox.Show("Order successfully!");
                    ClearField();
                }
                else
                {
                    MessageBox.Show("Ohh please try agian, We seem to have encountered an error!!");
                }
            }
            else
            {
                MessageBox.Show("Please, fill information and order at least one item!!");
            }
        }
        private void LoadBathNumber(int PartID)
        {
            orderItemBUL.GetBathByPart(cbbBatch, PartID);
            cbbBatch.DisplayMember = "BathNumber";
            cbbBatch.SelectedItem = null;
        }

        private void cboPartName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadBathNumber((int)cboPartName.SelectedValue);
        }
        private bool CheckAmountValid()
        {
            bool check = true;
            try
            {
                int.Parse(txtAmount.Text.ToString());
            }
            catch (Exception e)
            {
                check = false;
            }
            return check;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
