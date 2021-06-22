using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ODEV
{
    static class ProgramManager
    {
        public static Dictionary<string, User> Users = new Dictionary<string, User>();

        public static User activeUser;

        public static List<BalanceRequest> waitingBalanceRequests = new List<BalanceRequest>();

        public static List<SellOrder> waitingSellOrders = new List<SellOrder>();
        public static List<SellOrder> activeSellOrders = new List<SellOrder>();

        public static List<BuyOrder> buyOrders = new List<BuyOrder>();

        static int tradeId = 0;

        public static void HandleBalanceRequestApprove(BalanceRequest balanceRequest)
        {
            Users[balanceRequest.Mail].Balance += balanceRequest.Amount;
        }

        public static bool HandleBuy(SellOrder sellOrder)
        {
            float accountingShare = ((sellOrder.initialCost * 1) / 100);
            if (activeUser.Balance < sellOrder.initialCost + accountingShare)
            {
                return false;
            }
            else
            {
                activeUser.Balance -= (sellOrder.initialCost + accountingShare);
                ProgramManager.Users[sellOrder.SellerMail].Balance += sellOrder.initialCost;
                ProgramManager.Users["erenk@gmail.com"].Balance += accountingShare;
                return true;
            }
        }

        public static int GetTradeIdForReport()
        {
            return tradeId++;
        }

        public static void OtomaticBuy()
        {
            for (int i = 0; i < buyOrders.Count; i++)
            {
                for (int j = 0; j < activeSellOrders.Count; j++)
                {
                    if (buyOrders[i].Item == activeSellOrders[j].Item &&
                        buyOrders[i].Cost <= activeSellOrders[j].Cost &&
                        buyOrders[i].Amount == activeSellOrders[j].Amount)
                    {
                        if (HandleAutomaticBuy(buyOrders[i], activeSellOrders[j]))
                        {
                            CreateReport(buyOrders[i].BuyerMail, activeSellOrders[j]);
                            activeSellOrders.Remove(activeSellOrders[j]);
                            buyOrders.Remove(buyOrders[i]);
                        }
                    }
                }
            }
        }

        public static bool HandleAutomaticBuy(BuyOrder buyOrder, SellOrder sellOrder)
        {
            float accountingShare = ((sellOrder.initialCost * 1) / 100);
            if (Users[buyOrder.BuyerMail].Balance >= sellOrder.initialCost + accountingShare)
            {         
                ProgramManager.Users[buyOrder.BuyerMail].Balance -= (sellOrder.initialCost + accountingShare);
                ProgramManager.Users[sellOrder.SellerMail].Balance += sellOrder.initialCost;
                ProgramManager.Users["erenk@gmail.com"].Balance += accountingShare;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CreateReport(string buyerMail, SellOrder sellOrder)
        {
            string fileName = @"C:\Users\azizy\Desktop\Trade Report " + GetTradeIdForReport() + ".txt";
            using (StreamWriter sw = File.CreateText(fileName))
            {
                sw.WriteLine("Date: {0}", DateTime.Now.ToString());
                sw.WriteLine("Seller Information: {0}", sellOrder.SellerMail);
                sw.WriteLine("Buyer Information: {0}", buyerMail);
                sw.WriteLine("-----Trade Information-----");
                sw.WriteLine("Item: {0}", sellOrder.Item);
                sw.WriteLine("Amount: {0}", sellOrder.Amount);
                sw.WriteLine("Cost Per Amount: {0}", sellOrder.Cost);
                sw.WriteLine("Inital Cost: {0}", sellOrder.initialCost);
            }
        }
    }
}
