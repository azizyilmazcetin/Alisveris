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
    /// Interaction logic for BuyerWindow.xaml
    /// </summary>
    public partial class BuyerWindow : Window
    {
        
        public BuyerWindow()
        {
            ProgramManager.OtomaticBuy();
            InitializeComponent();
            ShowCurrentUserInformation();
            ShowActiveSellOrders();
            AddItemsToItemsCombo();
            ShowUserBuyOrders();
            AddCurrencysToCurrencyCombo();
            ShowExchangeValues();
        }

        private void ShowCurrentUserInformation()
        {
            UserInformation.Text = ProgramManager.activeUser.ToString();
        }

        private void AddItemsToItemsCombo()
        {
            ItemComboBox.Items.Add(Items.ItemsForSale.Barley);
            ItemComboBox.Items.Add(Items.ItemsForSale.Wheat);
            ItemComboBox.Items.Add(Items.ItemsForSale.Cotton);
            ItemComboBox.Items.Add(Items.ItemsForSale.Oil);
        }

        private void AddCurrencysToCurrencyCombo()
        {
            CurrencyComboBox.Items.Add(CurrencyManager.Currency.Lira);
            CurrencyComboBox.Items.Add(CurrencyManager.Currency.Usd);
            CurrencyComboBox.Items.Add(CurrencyManager.Currency.Euro);
            CurrencyComboBox.Items.Add(CurrencyManager.Currency.Sterlin);
        }

        private void ShowExchangeValues()
        {
            UsdLabel.Content = $"1 USD = {Math.Round(CurrencyManager.usd_sell,2)} Lira";
            EuroLabel.Content = $"1 EURO = {Math.Round(CurrencyManager.euro_sell, 2)} Lira";
            SterlinLabel.Content = $"1 GBP = {Math.Round(CurrencyManager.sterlin_sell, 2)} Lira";
        }

        private void ShowActiveSellOrders()
        {
            ActiveSellOrdersListView.Items.Clear();
            foreach (SellOrder request in ProgramManager.activeSellOrders)
            {
                ActiveSellOrdersListView.Items.Add(request);
            }
        }

        private void ShowUserBuyOrders()
        {
            foreach (BuyOrder buyOrder in ProgramManager.buyOrders)
            {
                if (buyOrder.BuyerMail == ProgramManager.activeUser.Email)
                {
                    BuyOrdersListView.Items.Add(buyOrder);
                }
            }
        }

        private void BalanceRequest(object sender, RoutedEventArgs e)
        {
            string name = ProgramManager.activeUser.Name;
            string lastName = ProgramManager.activeUser.LastName;
            string mail = ProgramManager.activeUser.Email;
            float amount = float.Parse(BalanceAmount.Text);
            CurrencyManager.Currency currencyType = (CurrencyManager.Currency)CurrencyComboBox.SelectedItem;

            BalanceRequest newBalanceRequest = new BalanceRequest(name,lastName,mail, amount, currencyType);
            CurrencyManager.HandleCurrencyExchange(newBalanceRequest);

            MessageBox.Show("Balance Request Sended For Admin Approval");
        }

        private void BuyOrder(object sender, RoutedEventArgs e)
        {
            var item = (Items.ItemsForSale)ItemComboBox.SelectedItem;
            float amount = float.Parse(ItemAmount.Text);
            float cost = float.Parse(ItemCost.Text);

            BuyOrder buyOrder = new BuyOrder(ProgramManager.activeUser.Email, amount, cost, item);
            ProgramManager.buyOrders.Add(buyOrder);
            MessageBox.Show("Buy Order Sended");
            ProgramManager.OtomaticBuy();
            ShowUserBuyOrders();
            ShowActiveSellOrders();
            ShowCurrentUserInformation();
        }

        private void ToLoginButtonClick(object sender, RoutedEventArgs e)
        {
            ProgramManager.activeUser = null;
            MainWindow objMainWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objMainWindow.Show();
        }

        private void ListViewBuyClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result;

            result = MessageBox.Show("Are you sure you want to approve selected purchase?", "Buy",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                if (ProgramManager.HandleBuy((SellOrder)ActiveSellOrdersListView.SelectedItem))
                {
                    MessageBox.Show("Succesfull!");
                    ProgramManager.activeSellOrders.Remove((SellOrder)ActiveSellOrdersListView.SelectedItem);
                    ProgramManager.CreateReport(ProgramManager.activeUser.Email,(SellOrder)ActiveSellOrdersListView.SelectedItem);
                }
                else
                {
                    MessageBox.Show("Not Enough Balance!");
                }                
                ShowActiveSellOrders();
                ShowCurrentUserInformation();               
            }
        }
    }
}
