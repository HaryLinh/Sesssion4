using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class Part
    {
        private int _ID;
        private string _PartName;
        private string _EffectiveLife;
        private bool _BathNumber;
        private int _MiniumAmount;
        private List<OrderItem> _OrderItems;

        public int ID { get => _ID; set => _ID = value; }
        public string PartName { get => _PartName; set => _PartName = value; }
        public string EffectiveLife { get => _EffectiveLife; set => _EffectiveLife = value; }
        public bool BathNumber { get => _BathNumber; set => _BathNumber = value; }
        public int MiniumAmount { get => _MiniumAmount; set => _MiniumAmount = value; }
        public List<OrderItem> OrderItems { get => _OrderItems; set => _OrderItems = value; }

        public Part()
        {
        }

        public Part(int iD, string partName, string effectiveLife, bool bathNumber, int miniumAmount, List<OrderItem> listOrderItem)
        {
            ID = iD;
            PartName = partName;
            EffectiveLife = effectiveLife;
            BathNumber = bathNumber;
            MiniumAmount = miniumAmount;
            OrderItems = listOrderItem;
        }
    }
}
