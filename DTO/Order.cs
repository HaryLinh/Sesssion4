using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Order
    {
        private int _ID;
        private TransactionType _TransactionType;
        private Supply _Supply;
        private WareHouse _SourceWareHouse;
        private WareHouse _Destination;
        private DateTime _OrderDate;

        public int ID { get => _ID; set => _ID = value; }
        public DateTime OrderDate { get => _OrderDate; set => _OrderDate = value; }
        internal TransactionType TransactionType { get => _TransactionType; set => _TransactionType = value; }
        internal Supply Supply { get => _Supply; set => _Supply = value; }
        internal WareHouse SourceWareHouse { get => _SourceWareHouse; set => _SourceWareHouse = value; }
        internal WareHouse Destination { get => _Destination; set => _Destination = value; }

        public Order()
        {
        }

        public Order(int iD, DateTime orderDate, TransactionType transactionType, Supply supply, WareHouse sourceWareHouse, WareHouse destination)
        {
            ID = iD;
            OrderDate = orderDate;
            TransactionType = transactionType;
            Supply = supply;
            SourceWareHouse = sourceWareHouse;
            Destination = destination;
        }
    }
}
