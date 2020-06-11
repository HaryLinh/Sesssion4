using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class Supply
    {
        int _ID;
        string _name;

        public int ID { get => _ID; set => _ID = value; }
        public string Name { get => _name; set => _name = value; }

        public Supply(int iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public Supply()
        {
        }
    }
}
