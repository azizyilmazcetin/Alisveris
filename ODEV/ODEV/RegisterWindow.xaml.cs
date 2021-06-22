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
using System.Windows.Shapes;

namespace ODEV
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {

        List<TextBox> textBoxes = new List<TextBox>();
        bool isSeller;

        public RegisterWindow()
        {
            InitializeComponent();
            
            textBoxes.Add(textBoxFirstname);
            textBoxes.Add(textBoxLastname);
            textBoxes.Add(textBoxNickname);
            textBoxes.Add(textBoxEmail);
            textBoxes.Add(textBoxPassword);
            textBoxes.Add(textBoxAddress);
            textBoxes.Add(textBoxTelephoneNumber);
            textBoxes.Add(textBoxId);
        }

        private void ReturnMainWindows(object sender, RoutedEventArgs e)
        {
            LoadMainWindow();         
        }

        private void LoadMainWindow()
        {
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Text = "";
            }                    
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            foreach (TextBox textBox in textBoxes)
            {
                if(!string.IsNullOrEmpty(textBox.Text))
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("Text Boxes Cannot Be Empty!");
                    return;
                }
            }

            string firstName = textBoxFirstname.Text;
            string lastName = textBoxLastname.Text;
            string nickName = textBoxNickname.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string address = textBoxAddress.Text;
            int telephoneNumber;
            int id;
            
            
            if(!Int32.TryParse(textBoxTelephoneNumber.Text, out telephoneNumber))
            {
                MessageBox.Show("Invalid Telephone Number!");
                return;
            }

            if (!Int32.TryParse(textBoxId.Text, out id))
            {
                MessageBox.Show("Invalid Id!");
                return;

            }

            if (isSeller)
            {
                Seller newSeller = new Seller(firstName, lastName, nickName, password, id, telephoneNumber, email, address, 0);
                ProgramManager.Users.Add(email, newSeller);
                MessageBox.Show("Register Succesfull");
                LoadMainWindow();
            }
            else
            {
                Buyer newBuyer = new Buyer(firstName, lastName, nickName, password, id, telephoneNumber, email, address, 0);
                ProgramManager.Users.Add(email, newBuyer);
                MessageBox.Show("Register Succesfull");
                LoadMainWindow();
            }                                                          
        }

        private void IsSellerChecked(object sender, RoutedEventArgs e)
        {
            isSeller = IsSeller.IsChecked == true;
        }
    }
}
