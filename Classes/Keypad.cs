using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Classes
{
    public class Keypad : INotifyPropertyChanged
    {
        private bool _canceledSelection;
        private bool _checkoutSelection;
        public string ItemSelection { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public bool CanceledSelection
        {
            get { return _canceledSelection; }
            set
            {
                _canceledSelection = value;
                OnPropertyChanged("CanceledSelection");
            }
        }

        public bool CheckOutSelection
        {
            get { return _checkoutSelection; }
            set
            {
                _checkoutSelection = value;
                OnPropertyChanged("CheckOutSelection");
            }
        }
        
        

        public void Cancel()
        {
            
        }

        public void CheckOut()
        {
            
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
