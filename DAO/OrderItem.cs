using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class OrderItem
    {
        private int _ID;
        private int _OrderID;
        private int _PartID;
        private string _BathNumber;
        private int _Amount;

        public int ID { get => _ID; set => _ID = value; }
        public int OrderID { get => _OrderID; set => _OrderID = value; }
        public int PartID { get => _PartID; set => _PartID = value; }
        public string BathNumber { get => _BathNumber; set => _BathNumber = value; }
        public int Amount { get => _Amount; set => _Amount = value; }
        
        public OrderItem()
        {

        }
    }
}
