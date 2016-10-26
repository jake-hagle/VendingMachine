using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class Transaction
    {
        public decimal ChangeDue { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal TotalChangeAvailable { get; set; }

        public decimal GetTotal(ShoppingCart cart)
        {
            var total = new decimal();
            return total;
        }

        public decimal DispenseChange(decimal changeDue)
        {
            return ChangeDue;
        }

    }
}
