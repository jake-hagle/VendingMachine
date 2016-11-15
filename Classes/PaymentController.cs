using System;
using System.Windows.Controls.Primitives;

namespace VendingMachine.Classes
{
    public class PaymentController
    {
        public decimal Payment { get; set; }
        public decimal CurrentPayment { get; set; }
        public decimal ChangeDue { get; set; }
        public decimal StoredChange { get; set; }
        public bool PaymentAccepted { get; set; }
        

        public void ComparePaymentToCost(decimal totalDue)
        {
            if (totalDue > CurrentPayment)
            {
                PaymentAccepted = false;
            }
            else
            {
                PaymentAccepted = true;
                if (CurrentPayment > totalDue)
                {
                    ChangeDue = CurrentPayment - totalDue;
                   
                }
                
            }
        }

        public decimal GiveChange()
        {
            return ChangeDue != 0 ? ChangeDue : 0;
        }

        public void CancelPayment()
        {
            if (CurrentPayment == 0) return;
            ChangeDue = CurrentPayment;
            GiveChange();
        }
        
    }
}