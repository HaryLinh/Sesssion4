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
    public partial class frmEditIventory : Form
    {
        TranSactionTypesBUL tran = new TranSactionTypesBUL();
        OrderBUL order = new OrderBUL();
        OrderItemBUL orderItem = new OrderItemBUL();
        PartBUL part = new PartBUL();
        WareHouseBUL wareHouse = new WareHouseBUL();
        List<object> listParams = new List<object>();

        public frmEditIventory()
        {
            InitializeComponent();
            listParams = (List<object>)Application.OpenForms["frmIventory"].Tag;
        }


        private void frmEditIventory_Load(object sender, EventArgs e)
        {

            LoadDataCboDesnstion();
            LoadDataCboSource();
            LoadDataPart();
            LoadDataTranSaction();
            LoadDataFormIventory();


        }
        public void LoadDataCboDesnstion()
        {
            wareHouse.GetAllWareHouse(cbbDesnitation);
            cbbDesnitation.DisplayMember = "WareHouseNam";
            cbbDesnitation.ValueMember = "ID";
            cbbDesnitation.SelectedItem = null;

        }
        public void LoadDataCboSource()
        {
            wareHouse.GetAllWareHouse(cbbSource);
            cbbSource.DisplayMember = "WareHouseNam";
            cbbSource.ValueMember = "ID";
            cbbSource.SelectedItem = null;

        }
        public void LoadDataPart()
        {
            part.GetAllParts(cbbPartName);
            cbbPartName.DisplayMember = "PartName";
            cbbPartName.ValueMember = "ID";
            cbbPartName.SelectedItem = null;

        }
        public void LoadDataTranSaction()
        {
            DataTable dataTran = tran.GetAllTranSaction();
            cbbTransaction.DataSource = dataTran;
            cbbTransaction.DisplayMember = "TranSactionName";
            cbbTransaction.ValueMember = "ID";
            cbbTransaction.SelectedItem = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            List<object> listParams = new List<object>();
            listParams = (List<object>)Application.OpenForms["frmIventory"].Tag;
            int OrderID = int.Parse(listParams[8].ToString());
            int IDes = int.Parse(cbbDesnitation.SelectedValue.ToString());
            int IDSource = int.Parse(cbbSource.SelectedValue.ToString());
            int TranID = int.Parse(cbbTransaction.SelectedValue.ToString());
            int OrderItemID = int.Parse(listParams[6].ToString());
            int PartID = int.Parse(cbbPartName.SelectedValue.ToString());
            int Amount = int.Parse(txtAmount.Text.ToString());
            DateTime Date = (DateTime)date.Value;
            if (order.UpdateOrder(OrderID, TranID, IDes, IDSource, Date) && orderItem.UpdateOrderItems(PartID, Amount, OrderItemID))
            {
                MessageBox.Show("Update successfully!!");
                this.Close();
            }
        }
        private void LoadDataFormIventory()
        {
            List<object> listParams = new List<object>();
            listParams = (List<object>)Application.OpenForms["frmIventory"].Tag;
            string PartName = listParams[0].ToString();
            string Destination = listParams[5].ToString();
            string Source = listParams[4].ToString();
            string Transaction = listParams[1].ToString();
            DateTime Date = (DateTime)listParams[2];
            string Amount = listParams[3].ToString();
            cbbPartName.SelectedIndex = cbbPartName.FindStringExact(PartName);
            cbbDesnitation.SelectedIndex = cbbDesnitation.FindStringExact(Destination);
            cbbSource.SelectedIndex = cbbSource.FindStringExact(Source);
            cbbTransaction.SelectedIndex = cbbTransaction.FindStringExact(Transaction);
            txtAmount.Text = Amount.ToString();
            date.Value = Date;
        }
    }
}
