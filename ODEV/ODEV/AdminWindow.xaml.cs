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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            AddSellersToCombo();
            AddBuyersToCombo();
            ShowBalanceRequests();
            ShowSellOrderRequests();
            ShowActiveSellOrders();
        }
        

        private void AddSellersToCombo()
        {
            SellersComboBox.Items.Clear();
            foreach (KeyValuePair<string,User> entry in ProgramManager.Users)
            {
                if(entry.Value.IsSeller)
                {
                    SellersComboBox.Items.Add(entry.Value);
                }
            }
        }

        private void AddBuyersToCombo()
        {
            BuyersComboBox.Items.Clear();
            foreach (KeyValuePair<string, User> entry in ProgramManager.Users)
            {
                if (!entry.Value.IsSeller && !entry.Value.IsAdmin)
                {
                    BuyersComboBox.Items.Add(entry.Value);
                }
            }
        }

        private void ShowBalanceRequests()
        {
            ListView.Items.Clear();
            foreach (BalanceRequest request in ProgramManager.waitingBalanceRequests)
            {            
                ListView.Items.Add(request);
            }
        }

        private void ShowSellOrderRequests()
        {
            SellOrdersListView.Items.Clear();
            foreach (SellOrder request in ProgramManager.waitingSellOrders)
            {
                SellOrdersListView.Items.Add(request);
            }
        }

        private void ShowActiveSellOrders()
        {
            ActiveSellOrdersListView.Items.Clear();
            foreach(SellOrder request in ProgramManager.activeSellOrders)
            {
                ActiveSellOrdersListView.Items.Add(request);
            }
        }

        private void ListViewBalanceRequestClick(object sender, MouseButtonEventArgs e)
        {
            BalanceRequest selectedRequest = (BalanceRequest)ListView.SelectedItem;
            MessageBoxResult result;

            result = MessageBox.Show("Do you approve selected balance request?", "Balance Request",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                ProgramManager.waitingBalanceRequests.Remove(selectedRequest);
                ProgramManager.HandleBalanceRequestApprove(selectedRequest);
                ShowBalanceRequests();
                AddSellersToCombo();
                AddBuyersToCombo();
            }

            else
            {
                ProgramManager.waitingBalanceRequests.Remove(selectedRequest);
                ShowBalanceRequests();
            }
        }

        private void ListViewSellRequestClick(object sender, MouseButtonEventArgs e)
        {
            SellOrder selectedRequest = (SellOrder)SellOrdersListView.SelectedItem;
            MessageBoxResult result;

            result = MessageBox.Show("Do you approve selected sell order?", "Sell order",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                ProgramManager.waitingSellOrders.Remove(selectedRequest);
                ProgramManager.activeSellOrders.Add(selectedRequest);
                ShowSellOrderRequests();
                AddSellersToCombo();
                AddBuyersToCombo();
                ProgramManager.OtomaticBuy();
                ShowActiveSellOrders();             
            }
            else
            {
                ProgramManager.waitingSellOrders.Remove(selectedRequest);
                ShowSellOrderRequests();
            }
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
