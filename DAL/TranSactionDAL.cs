using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TranSactionDAL
    {
        public DataTable GetAllTranSaction()
        {
            string sql = "Select * from TranSactionTypes";
            return Utility.ExecuteDataReader(sql);

        }
    }
}
