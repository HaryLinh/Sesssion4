using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class WareHouse
    {
        private int _ID;

        private string _WareHouseNam;

        private List<Order> _Orders;

        public int ID { get => _ID; set => _ID = value; }
        public string WareHouseNam { get => _WareHouseNam; set => _WareHouseNam = value; }
        internal List<Order> Orders { get => _Orders; set => _Orders = value; }

        public WareHouse()
        {
        }

        public WareHouse(int iD, string wareHouseNam, List<Order> orders)
        {
            ID = iD;
            WareHouseNam = wareHouseNam;
            Orders = orders;
        }
    }
}
