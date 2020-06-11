using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderItem
    {
        private int _ID;
        private Order _Order;
        private Part _Part;
        private string _BathNumber;
        private int _Amount;

        public int ID { get => _ID; set => _ID = value; }
        public string BathNumber { get => _BathNumber; set => _BathNumber = value; }
        public int Amount { get => _Amount; set => _Amount = value; }
        internal Order Order { get => _Order; set => _Order = value; }
        internal Part Part { get => _Part; set => _Part = value; }

        public OrderItem()
        {
        }

        public OrderItem(int iD, string bathNumber, int amount, Order order, Part part)
        {
            ID = iD;
            BathNumber = bathNumber;
            Amount = amount;
            Order = order;
            Part = part;
        }
    }
}
