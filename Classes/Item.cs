using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class Item
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }

    }
}
