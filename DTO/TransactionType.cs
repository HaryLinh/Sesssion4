using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TransactionType
    {
        private int _ID;

        private string _TransactionTypeName;

        private List<Order> _Orders;

        public int ID { get => _ID; set => _ID = value; }
        public string TransactionTypeName { get => _TransactionTypeName; set => _TransactionTypeName = value; }
        public List<Order> Orders { get => _Orders; set => _Orders = value; }

        public TransactionType()
        {
        }

        public TransactionType(int iD, string transactionTypeName, List<Order> orders)
        {
            ID = iD;
            TransactionTypeName = transactionTypeName;
            Orders = orders;
        }
    }
}
