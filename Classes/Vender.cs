using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class Vender
    {
        public List<Item> Items { get; set; }
        public bool PaymentReceived { get; set; }


        public bool CheckPayment()
        {
            return true;
        }

        public void Vend(List<Item> vendItems)
        {
            
        }


    }
}
