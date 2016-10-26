using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class Inventory
    {
        public List<Item> Items { get; set; }

        public void AddToCart(Item selection)
        {

        }

        public bool CheckAvailability(Item selection)
        {
            return true;
        }

        public List<Item> GenerateInventory(FileStream inventoryFile)
        {
            return new List<Item>();
        }

    }

}
