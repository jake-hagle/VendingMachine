using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
        public MainWindow()
        {
            InitializeComponent();
            var keypad = new Keypad();
            var inventory = new Inventory();
            var inventoryFile = new FileStream("file.txt", FileMode.Open);
            var shoppingCart = new ShoppingCart();
            var transactions = new Transaction();
            var vender = new Vender();

            inventory.Items = inventory.GenerateInventory(inventoryFile);
            
            

        }
            





    }
}
