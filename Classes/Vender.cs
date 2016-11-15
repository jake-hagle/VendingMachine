using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VendingMachine.Classes
{
    public class Vender
    {
        public Item Item { get; set; }

         

        public void Vend(Item vendItem, TextBlock outputTextBlock)
        {
            outputTextBlock.Text += "Vending Item: " + vendItem.Name;
        }

        public void RemoveItem(Inventory currentInventory)
        {
         //Remove item loaded inventory   
        }


    }
}
