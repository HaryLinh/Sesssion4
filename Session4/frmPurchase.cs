using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUL;
namespace Session4
{
    public partial class frmPurchase : Form
    {
        SupplyBUL supplyBUL = new SupplyBUL();
        WareHouseBUL wareHouseBUL = new WareHouseBUL();
        PartBUL partBUL = new PartBUL();
        OrderBUL orderBUL = new OrderBUL();
        OrderItemBUL orderItemBUL = new OrderItemBUL();
        DataTable data;
        Hashtable hashPart = new Hashtable();
        public frmPurchase()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            data = InitTable();
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            LoadDataCboSupply();
            LoadDataCboWareHouse();
            LoadDataCboPart();
            LoadAction();
            data.Columns[3].ColumnMapping = MappingType.Hidden;
        }
        public void LoadDataCboSupply()
        {
            supplyBUL.GetAllSupplies(cbSupply);
            cbSupply.DisplayMember = "SupplyName";
            cbSupply.ValueMember = "ID";
            cbSupply.SelectedItem = null;
            cbSupply.SelectedText = "Please, choose a supply....";
        }
        public void LoadDataCboWareHouse()
        {
            wareHouseBUL.GetAllWareHouse(cboWareHouse);
            cboWareHouse.DisplayMember = "WareHouseNam";
            cboWareHouse.ValueMember = "ID";
            cboWareHouse.SelectedItem = null;
            cboWareHouse.SelectedText = "Please, choose a warehouse....";
        }
        public void LoadDataCboPart()
        {
            partBUL.GetAllParts(cboPartName);
            cboPartName.DisplayMember = "PartName";
            cboPartName.ValueMember = "ID";
            cboPartName.SelectedItem = null;
            cboPartName.SelectedText = "Please, choose a part....";
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            if (cboPartName.SelectedIndex < 0 || txtAmount.Text == "" || !CheckAmount())
            {
                MessageBox.Show("Please choose and fill information and amount is a number");
            }
            else
            {
                string exp = "PartName = '" + cboPartName.Text + "' AND BatchNumber = '"+ txtBatch.Text +"'";
                int ID = int.Parse(cboPartName.SelectedValue.ToString());
                int Amount = int.Parse(txtAmount.Text.ToString());
                bool checkPartRequire = partBUL.CheckHasRequire(ID);
                if (checkPartRequire && txtBatch.Text == "")
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
                        if(hashPart != null && hashPart[ID] != null)
                        {
                            Amount += (int)hashPart[ID];
                        }
                        if (CheckAmount(ID, Amount))
                        {
                            if (!hashPart.ContainsKey(ID))
                            {
                                hashPart.Add(ID, Amount);
                            }
                            data.Rows.Add(cboPartName.Text, checkPartRequire ? txtBatch.Text : "", txtAmount.Text, ID);
                            dataGird.DataSource = data;
                        }
                        else
                        {
                            MessageBox.Show("Sorry,Out of stock !!");
                        }
                    }
                    else
                    {
                        if (hashPart != null && hashPart[ID] != null)
                        {
                            Amount = (int)hashPart[ID];
                        }
                        int index = data.Rows.IndexOf(dr[0]);
                        if (CheckAmount(ID, int.Parse(data.Rows[index]["Amount"].ToString()) + Amount))
                        {
                            if (hashPart.ContainsKey(ID))
                            {
                                hashPart[ID] = int.Parse(data.Rows[index]["Amount"].ToString()) + Amount;
                            }
                            data.Rows[index]["Amount"] = int.Parse(data.Rows[index]["Amount"].ToString()) + Amount;
                        }
                        else
                        {
                            MessageBox.Show("Sorry,Out of stock !!");
                        }

                    }
                }
            }
        }

        private DataTable InitTable()
        {
            DataTable data = new DataTable();
            data.Columns.Add("PartName", typeof(string));
            data.Columns.Add("BatchNumber", typeof(string));
            data.Columns.Add("Amount", typeof(int));
            data.Columns.Add("PartID", typeof(int));
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm() && data.Rows.Count > 0)
            {
                if (InsertOrder() && InsertAllOrderItem())
                {
                    UpdateAmount();
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

        private void dataGird_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGird.Columns["delete"].Index && e.RowIndex >= 0)
            {
                data.Rows[e.RowIndex].Delete();
                data.AcceptChanges();
            }
        }
        private bool CheckAmount(int ID, int Amount)
        {
            bool check = false;
            int MiniumAmount = partBUL.GetAmountByID(ID);
            if (Amount <= MiniumAmount)
                check = true;

            return check;
        }
        private void UpdateAmount()
        {
            foreach (DataRow row in data.Rows)
            {
                int PartID = int.Parse(row["PartID"].ToString());
                int Amount = int.Parse(row["Amount"].ToString());
                int MiniumAmount = partBUL.GetAmountByID(PartID);
                partBUL.UpdateAmount(MiniumAmount - Amount, PartID);
            }
        }
        
        private bool InsertOrder()
        {
            int SupplyID = int.Parse(cbSupply.SelectedValue.ToString());
            int WareHouse = int.Parse(cboWareHouse.SelectedValue.ToString());
            DateTime date = DateTime.Parse(dateTimePicker1.Value.ToString());
            return orderBUL.InserOrder(SupplyID, WareHouse, date);
        }
        private bool InsertAllOrderItem()
        {
            bool check = true;
            int OrderID = orderBUL.GetOrderID();
            foreach (DataRow row in data.Rows)
            {
                int PartID = int.Parse(row["PartID"].ToString());
                string BatchNumber = row["BatchNumber"].ToString();
                int Amount = int.Parse(row["Amount"].ToString());
                try
                {
                    orderItemBUL.InsertOrderItem(OrderID, PartID, BatchNumber, Amount);
                }
                catch(Exception e)
                {
                    check = false;
                    break;
                }
            }
            return check;
        }
        private bool ValidateForm()
        {
            bool check = false;
            if (cbSupply.SelectedIndex >= 0 && cboWareHouse.SelectedIndex >= 0)
                check = true;
            return check;
        }
        private bool CheckAmount()
        {
            bool check = true;
            try
            {
                int.Parse(txtAmount.Text.ToString());
            }catch(Exception e)
            {
                check = false;
            }
            return check;
        }
        private void ClearField()
        {
            cboPartName.SelectedIndex = -1;
            cboWareHouse.SelectedIndex = -1;
            cbSupply.SelectedIndex = -1;
            txtBatch.Text = "";
            txtAmount.Text = "";
            data.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
