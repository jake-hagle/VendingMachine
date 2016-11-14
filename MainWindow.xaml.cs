using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VendingMachine.Classes;

namespace VendingMachine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Inventory Inventory { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Vender Vender { get; set; }
        public Keypad Keypad { get; set; }
        public InventoryController InventoryController { get; set; }
        public PaymentController PaymentController { get; set; }


        public MainWindow()
        {
            
            InitializeComponent();
            
            Inventory = new Inventory();
            ShoppingCart = new ShoppingCart();
            Vender = new Vender();
            Keypad = new Keypad();
            InventoryController = new InventoryController();
            PaymentController = new PaymentController();

            //var inventoryFile = new FileStream("file.txt", FileMode.Open);
            //Inventory.Items = Inventory.GenerateInventory(inventoryFile);

        }

        public void PayOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var paymentButton = (Button) sender;
            var contents = paymentButton.Content;
            var amountPaid = Convert.ToDecimal(contents);
            PaymentController.CurrentPayment += amountPaid;

        }

        public void SelectItemOnClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Button) sender;
            InventoryController.ItemSelection = selectedItem.Uid;
            var isAvailable = InventoryController.CheckProductAvailability(InventoryController.ItemSelection,
                    Inventory);
            if (isAvailable)
            {
                InventoryController.SelectedItem =
                    Inventory.Items.FirstOrDefault(x => x.Location == InventoryController.ItemSelection);
                ShoppingCart.CartItems.Add(InventoryController.SelectedItem);
               // PRINT ITEM IS ADDED TO CART
            }
            else
            {
               // Print not available make new selection
            }
        }

        public void CheckOutOnClick(object sender, RoutedEventArgs e)
        {
            InventoryController.Total = InventoryController.CalcTotal(ShoppingCart);
            if (InventoryController.Total == 0) return;
            if (PaymentController.CurrentPayment != 0)
            {
                PaymentController.ComparePaymentToCost(InventoryController.Total);
                if (PaymentController.PaymentAccepted)
                {
                    if (PaymentController.ChangeDue != 0)
                    {
                        PaymentController.GiveChange();
                    }

                    foreach (var item in ShoppingCart.CartItems)
                    {
                        Vender.Vend(item);
                        Vender.RemoveItem(Inventory);
                    }
                }
                else
                {
                    //Payment not accepted, please try again 
                }
            }
            else
            {
                //Please insert payment and try again
                return;
            }
        }

        public void CancelOnClick(object sender, RoutedEventArgs e)
        {

            ShoppingCart.ClearCart();
            PaymentController.CancelPayment();
            
        }




    }
}
