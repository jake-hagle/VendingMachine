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
            
            return true;
        }

        

        public void ClearCart(bool canClear, ShoppingCart currentCart)
        {
            if (currentCart.CartItems.Count > 0)
            {
                currentCart.CartItems = new List<Item>();
            }
        }

        

        public decimal CalcTotal(ShoppingCart currentCart)
        {
            
            foreach (var item in currentCart.CartItems)
            {
                Total += item.Price;
            }
            return Total;
        }

}
}
