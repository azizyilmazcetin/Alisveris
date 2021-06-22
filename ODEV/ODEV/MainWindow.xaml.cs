using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ODEV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateAdminAccount();
            CreateSellers();
            CreateBuyers();
            CurrencyManager.GetCurrencyValues();
            CreateAccountant();
        }

        private void OpenRegisterWindow(object sender, RoutedEventArgs e)
        {
            RegisterWindow objRegisterWindow = new RegisterWindow();
            this.Visibility = Visibility.Hidden;
            objRegisterWindow.Show();
        }

        private void CreateAdminAccount()
        {
            string email = "azizyilmazcetin@gmail.com";
            if(!ProgramManager.Users.ContainsKey(email))
            {
                AdminUser admin = new AdminUser("Aziz", "Çetin", "AY", "123", 1, 555555555, email, "Hatay");
                ProgramManager.Users.Add(email, admin);
            }         
        }

        private void CreateSellers()
        {
            string sellerEmail = "ahmet@gmail.com";
            if (!ProgramManager.Users.ContainsKey(sellerEmail))
            {
                Seller seller = new Seller("Ahmet", "Kar", "Ahmet50", "123", 15597434 , 53064512, sellerEmail, "Nevşehir", 100);
                ProgramManager.Users.Add(sellerEmail, seller);
            }

            string sellerEmail1 = "mehmet@gmail.com";
            if (!ProgramManager.Users.ContainsKey(sellerEmail1))
            {
                Seller seller = new Seller("Mehmet", "Çetin", "MÇ", "123", 16549743, 56124516, sellerEmail1, "Hatay", 100);
                ProgramManager.Users.Add(sellerEmail1, seller);
            }

            string sellerEmail2 = "hasan@gmail.com";
            if (!ProgramManager.Users.ContainsKey(sellerEmail2))
            {
                Seller seller = new Seller("Hasan", "Karabasan", "HK123", "123", 16512346, 5654978, sellerEmail2, "İstanbul", 100);
                ProgramManager.Users.Add(sellerEmail2, seller);
            }
        }

        private void CreateBuyers()
        {
            string buyerEmail = "huseyin@gmail.com";
            if (!ProgramManager.Users.ContainsKey(buyerEmail))
            {
                Buyer buyer = new Buyer("Hüseyin", "Ersoy", "Hüso", "123", 15697484, 43264582, buyerEmail, "Kastamonu", 200);
                ProgramManager.Users.Add(buyerEmail, buyer);
            }

            string buyerEmail1 = "kemal@gmail.com";
            if (!ProgramManager.Users.ContainsKey(buyerEmail1))
            {
                Buyer buyer = new Buyer("Kemal", "Can", "KC5353", "123", 16597836, 52014592, buyerEmail1, "Rize", 300);
                ProgramManager.Users.Add(buyerEmail1, buyer);
            }

            string buyerEmail2 = "bayram@gmail.com";
            if (!ProgramManager.Users.ContainsKey(buyerEmail2))
            {
                Buyer buyer = new Buyer("Bayram", "Ramazan", "BayramR", "123", 19997524, 53071552, buyerEmail2, "Nevşehir", 400);
                ProgramManager.Users.Add(buyerEmail2, buyer);
            }
        }

        private void CreateAccountant()
        {
            string accountantEmail = "erenk@gmail.com";
            if (!ProgramManager.Users.ContainsKey(accountantEmail))
            {
                Accountant accountant = new Accountant("Eren", "Kaya", "ErenKAYA", "123", 19697434, 43664592, accountantEmail, "Kastamonu");
                ProgramManager.Users.Add(accountantEmail, accountant);
            }
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            string email = textBoxEmail.Text;
            string password = textPassword.Password;
            if(ProgramManager.Users.ContainsKey(email) && ProgramManager.Users[email].Password == password)
            {
                ProgramManager.activeUser = ProgramManager.Users[email];
                if(ProgramManager.activeUser.IsAdmin)
                {
                    AdminWindow objAdminWindow = new AdminWindow();
                    this.Visibility = Visibility.Hidden;
                    objAdminWindow.Show();
                }
                else if(ProgramManager.activeUser.IsSeller)
                {
                    SellerWindow objSellerWindow = new SellerWindow();
                    this.Visibility = Visibility.Hidden;
                    objSellerWindow.Show();
                }
                else
                {
                    BuyerWindow objBuyerWindow = new BuyerWindow();
                    this.Visibility = Visibility.Hidden;
                    objBuyerWindow.Show();
                }
            }
            else
            {
                MessageBox.Show("Invalid User!");
            }
        }
    }
}
