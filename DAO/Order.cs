using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Order
    {
        private int _ID;
        private int _TranSactionID;
        private int _SupplyID;
        private int _SourceWareID;
        private int _DestinationID;
        private DateTime _OrderDate;
        public int ID { get => _ID; set => _ID = value; } 
        public int TranSactionID { get => _TranSactionID; set => _TranSactionID = value; }
        public int SupplyID { get => _SupplyID; set => _SupplyID = value; }
        public int SourceWareID { get => _SourceWareID; set => _SourceWareID = value; }
        public int DestinationID { get => _DestinationID; set => _DestinationID = value; }
        public DateTime OrderDate { get => _OrderDate; set => _OrderDate = value; }

        public Order()
        {

        }
    }
}
