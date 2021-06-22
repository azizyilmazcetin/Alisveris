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
    /// Interaction logic for StandartUserWindow.xaml
    /// </summary>
    public partial class SellerWindow : Window
    {
        public SellerWindow()
        {
            ProgramManager.OtomaticBuy();
            InitializeComponent();
            ShowCurrentUserInformation();
            AddItemsToCombo();
            ShowUserActiveSellOrders();
            ShowUserWaitingSellOrders();
            ShowBuyOrders();
        }   

        private void ShowCurrentUserInformation()
        {
            UserInformation.Text = ProgramManager.activeUser.ToString();
        }

        private void ShowBuyOrders()
        {
            foreach (BuyOrder buyOrder in ProgramManager.buyOrders)
            {
                BuyOrdersListView.Items.Add(buyOrder);
            }
        }

        private void ShowUserActiveSellOrders()
        {
            foreach (SellOrder sellOrder in ProgramManager.activeSellOrders)
            {
                if(sellOrder.SellerMail == ProgramManager.activeUser.Email)
                {
                    ListViewActive.Items.Add(sellOrder);
                }
            }
        }

        private void ShowUserWaitingSellOrders()
        {
            foreach (SellOrder sellOrder in ProgramManager.waitingSellOrders)
            {
                if (sellOrder.SellerMail == ProgramManager.activeUser.Email)
                {
                    ListViewWaiting.Items.Add(sellOrder);
                }
            }
        }

        private void AddItemsToCombo()
        {
            ItemComboBox.Items.Add(Items.ItemsForSale.Barley);
            ItemComboBox.Items.Add(Items.ItemsForSale.Wheat);
            ItemComboBox.Items.Add(Items.ItemsForSale.Cotton);
            ItemComboBox.Items.Add(Items.ItemsForSale.Oil);
        }

        private void SellOrder(object sender, RoutedEventArgs e)
        {
            var item = (Items.ItemsForSale)ItemComboBox.SelectedItem;
            float amount = float.Parse(ItemAmount.Text);
            float cost = float.Parse(ItemCost.Text);

            SellOrder sellOrder = new SellOrder(ProgramManager.activeUser.Email, amount, cost, item);
            ProgramManager.waitingSellOrders.Add(sellOrder);
            MessageBox.Show("Sell Order Request Sended For Admin Approval");
            ShowUserWaitingSellOrders();
            ProgramManager.OtomaticBuy();
            ShowCurrentUserInformation();
            ShowUserActiveSellOrders();
        }

        private void ToLoginButtonClick(object sender, RoutedEventArgs e)
        {
            ProgramManager.activeUser = null;
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }
    }
}
