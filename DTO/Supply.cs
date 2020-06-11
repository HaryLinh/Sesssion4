using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Supply
    {
        private int _ID;

        private string _SupplyName;

        private List<Order> _Orders;

        public int ID { get => _ID; set => _ID = value; }
        public string SupplyName { get => _SupplyName; set => _SupplyName = value; }
        public List<Order> Orders { get => _Orders; set => _Orders = value; }

        public Supply()
        {
        }

        public Supply(int iD, string supplyName, List<Order> orders)
        {
            ID = iD;
            SupplyName = supplyName;
            Orders = orders;
        }
    }
}
