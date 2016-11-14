using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class Vender
    {
        public Item Item { get; set; }

         

        public void Vend(Item vendItem)
        {
            Console.Write(Item);
        }

        public void RemoveItem(Inventory currentInventory)
        {
         //Remove item loaded inventory   
        }


    }
}
