using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace BUL
{
    public class PartBUL
    {
        public void GetAllParts(ComboBox combo)
        {
            combo.DataSource = new PartDAL().GetAllParts();
        }

        public Boolean CheckHasRequire(int PartID)
        {
            return new PartDAL().CheckHasRequire(PartID);
        }
        public int GetAmountByID(int ID)
        {
            return new PartDAL().GetAmountByID(ID);
        }
        public bool UpdateAmount(int Amount , int ID)
        {
            return new PartDAL().UpdateAmount(Amount, ID);
        }
        public void GetPartBySource(ComboBox combo, int Source)
        {
            combo.DataSource = new PartDAL().GetPartBySource(Source);
        }
    }
}
