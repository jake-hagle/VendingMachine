using System;

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
                Console.Write("More Moniez peeasssee");
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

        public void GiveChange()
        {
            Console.Write("HERES YOUR CHANGE! {1}", ChangeDue.ToString() );

        }

        public void CancelPayment()
        {
            if (CurrentPayment == 0) return;
            ChangeDue = CurrentPayment;
            GiveChange();
        }
        
    }
}