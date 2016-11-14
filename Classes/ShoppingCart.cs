using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class ShoppingCart
    {
        public List<Item> CartItems { get; set; }

        public void ClearCart()
        {
            CartItems = new List<Item>();
        }
        
    }
}
