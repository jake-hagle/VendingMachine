using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class Inventory
    {
        public List<Item> Items { get; set; }


        public List<Item> GenerateInventory(string fileLocation)
        {
            Items = new List<Item>();
            var path = Directory.GetCurrentDirectory() + "\\file.txt";


            var lines = File.ReadLines(path);

            foreach (var line in lines)
            {
                var splitter = line.Split(',');
                var tempItem = new Item();
                tempItem.Name = splitter[0];
                tempItem.Price = Convert.ToDecimal(splitter[1]);
                tempItem.Quantity = Convert.ToInt32(splitter[2]);
                tempItem.Location = splitter[3];

                Items.Add(tempItem);
            }

            return Items;
        }

        public void SaveInventory(FileStream inventoryFile)
        {
            //Write new inventory to file
        }

    }

}
