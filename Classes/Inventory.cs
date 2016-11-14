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


        public List<Item> GenerateInventory(FileStream inventoryFile)
        {
           
           
            //foreach line in file create new item class and fill with information from file
            return new List<Item>();
        }

        public void SaveInventory(FileStream inventoryFile)
        {
            //Write new inventory to file
        }

    }

}
