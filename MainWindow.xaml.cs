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
            ShoppingCart.CartItems = new List<Item>();
            Vender = new Vender();
            Keypad = new Keypad();
            InventoryController = new InventoryController();
            InventoryController.SelectedItem = new Item();
            PaymentController = new PaymentController();

            var inventoryFile = "file.txt";
            Inventory.Items = Inventory.GenerateInventory(inventoryFile);

            VendingMachineOutput.Text = "Vendo-Tron 3000:\n Please make a selection!\n";
            VendingMachineOutput.ScrollToEnd();

        }

        public void PayOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            var paymentButton = (Button) sender;
            var contents = paymentButton.Content;
            var amountPaid = Convert.ToDecimal(contents);
            PaymentController.CurrentPayment += amountPaid;
            VendingMachineOutput.Text += "Amount Paid: $" + PaymentController.CurrentPayment + "\n";
            VendingMachineOutput.ScrollToEnd();
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
                    Inventory.Items.Find(x => x.Location.Equals(InventoryController.ItemSelection));


                if (InventoryController.SelectedItem == null) return;
                if (ShoppingCart.CartItems.Count() == 0 || !ShoppingCart.CartItems.Any(x=>x.Location == InventoryController.SelectedItem.Location))
                {
                    var tempItem = new Item();
                    tempItem.Name = InventoryController.SelectedItem.Name; 
                    tempItem.Quantity = 1;
                    tempItem.Location = InventoryController.SelectedItem.Location;
                    tempItem.Price = InventoryController.SelectedItem.Price;
                    ShoppingCart.CartItems.Add(tempItem);
                    VendingMachineOutput.Text += "\n" + InventoryController.SelectedItem.Name +
                                                 " has been added to the cart.\n";
                    VendingMachineOutput.ScrollToEnd();
                    return;
                }
                foreach (var item in ShoppingCart.CartItems)
                {
                    if (item.Location.Equals(InventoryController.SelectedItem.Location))
                    {
                        if (item.Quantity + 1 <= InventoryController.SelectedItem.Quantity)
                        {
                            item.Quantity += 1;
                            //ShoppingCart.CartItems.Add(InventoryController.SelectedItem);
                            VendingMachineOutput.Text += "\n" + InventoryController.SelectedItem.Name +
                                                         " has been added to the cart.\n";
                            VendingMachineOutput.ScrollToEnd();
                            break;
                        }
                        else
                        {
                            VendingMachineOutput.Text += "\n" + InventoryController.SelectedItem.Name +
                                                         " is not available.\n";
                            VendingMachineOutput.ScrollToEnd();
                            break;
                        }
                    } 
                }
                
            }
            else
            {
                VendingMachineOutput.Text +=
                    "The item you selected is no longer available. Please select another item\n";
                VendingMachineOutput.ScrollToEnd();
            }
        }

        public void CheckOutOnClick(object sender, RoutedEventArgs e)
        {

            InventoryController.Total = InventoryController.CalcTotal(ShoppingCart);
            if (InventoryController.Total == 0) return;
            if (PaymentController != null && PaymentController.CurrentPayment != 0)
            {
                PaymentController.ComparePaymentToCost(InventoryController.Total);
                if (PaymentController.PaymentAccepted)
                {
                    

                    foreach (var item in ShoppingCart.CartItems)
                    {
                        Vender.Item = item;
                        Vender.Vend(VendingMachineOutput);
                        Inventory = Vender.RemoveItem(Inventory);
                    }

                    var changeDue = PaymentController.GiveChange(InventoryController.Total);

                    if (changeDue != 0)
                    {
                        
                        VendingMachineOutput.Text += "Dispensing Change...\n" + "Change Due: $" + changeDue + "\n";
                        VendingMachineOutput.ScrollToEnd();
                        PaymentController.ChangeDue = 0;

                    }

                    InventoryController.Total = 0;
                    ShoppingCart.ClearCart();

                    VendingMachineOutput.Text += "\n Please make a selection or insert payment.\n";
                    VendingMachineOutput.ScrollToEnd();




                }
                else
                {
                    VendingMachineOutput.Text += "Please insert more money.\n Amount Paid: $" +
                                                 PaymentController.CurrentPayment + "\n" + "Total Due: $" +
                                                 InventoryController.Total + "\n";
                    VendingMachineOutput.ScrollToEnd();
                }
            }
            else
            {
                if (ShoppingCart.CartItems.Count() != 0)
                {
                    VendingMachineOutput.Text += "Please insert payment.\n";
                    VendingMachineOutput.ScrollToEnd();
                }
                else
                {
                    VendingMachineOutput.Text += "Please make a selection or insert payment.\n";
                    VendingMachineOutput.ScrollToEnd();
                }
                
            }
        }

        public void CancelOnClick(object sender, RoutedEventArgs e)
        {
           
            
            var changeDue = PaymentController.GiveChange(InventoryController.Total);
            if (changeDue != 0)
            {
                
                VendingMachineOutput.Text += "Dispensing Change...\n" + "Change Due: $" + changeDue + "\n";
                VendingMachineOutput.ScrollToEnd();

            }
            else if (ShoppingCart.CartItems.Count() != 0 && PaymentController.Payment == 0)
            {
                VendingMachineOutput.Text += "Canceling Transaction...\n";
                VendingMachineOutput.ScrollToEnd();
            }
            else
            {
                VendingMachineOutput.Text += "Please make a selection.\n";
                VendingMachineOutput.ScrollToEnd();
            }

            ShoppingCart.ClearCart();
            PaymentController.CancelPayment();



        }




    }
}
