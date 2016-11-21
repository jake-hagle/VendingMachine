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
            }

            
        }

        public decimal GiveChange(decimal totalDue)
        {
            if (CurrentPayment != 0 && totalDue == 0)
            {
                ChangeDue = CurrentPayment;
            }else if (CurrentPayment != 0 && CurrentPayment < totalDue)
            {
                ChangeDue = CurrentPayment;
            }   
            else if (CurrentPayment > totalDue)
            {
                ChangeDue = CurrentPayment - totalDue;
            }
            else
            {
                ChangeDue = 0;
            }
            CurrentPayment = 0;
            return ChangeDue;
        }

        public void CancelPayment()
        {
            if (CurrentPayment == 0) return;
            
            ChangeDue = 0;
            CurrentPayment = 0;
            
        }
        
    }
}