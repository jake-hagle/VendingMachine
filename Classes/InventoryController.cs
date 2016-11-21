using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VendingMachine.Classes
{
    public class InventoryController
    {

        public string ItemSelection { get; set; }
        public Item SelectedItem { get; set; }
        public decimal Total { get; set; }



        public bool CheckProductAvailability(string selectedItem, Inventory currentInventory)
        {
            var temp = currentInventory.Items.FirstOrDefault(x => x.Location == selectedItem);
            if (temp == null) return false;
            if (temp.Quantity > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
       

        public decimal CalcTotal(ShoppingCart currentCart)
        {
            Total = 0;
            foreach (var item in currentCart.CartItems)
            {
                Total += item.Price * item.Quantity;
            }
            return Total;
        }

}
}
