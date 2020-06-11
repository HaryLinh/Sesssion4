using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUL
{
    public class TranSactionTypesBUL
    {
        public DataTable GetAllTranSaction()
        {
           return new TranSactionDAL().GetAllTranSaction();
        }
    }
}
