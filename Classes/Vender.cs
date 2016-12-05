using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VendingMachine.Classes
{
    public class Vender
    {
        public Item Item { get; set; }

         
        
        public void Vend(TextBox outputTextBlock)
        {
            if (Item.Quantity >= 1)
            {
                var i = Item.Quantity;
                while (i != 0)
                {
                    outputTextBlock.Text += "Vending Item: " + Item.Name + "\n";
                    
                    i -= 1;
                }
            }
            
        }

        public Inventory RemoveItem(Inventory currentInventory)
        {
            
            var temp = currentInventory.Items.Find(x=>x.Location == Item.Location);
            temp.Quantity -= Item.Quantity;

            return currentInventory;
            

        }


    }
}
