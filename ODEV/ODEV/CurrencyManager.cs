using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ODEV
{
    static class CurrencyManager
    {
        const string exchange = "https://www.tcmb.gov.tr/kurlar/today.xml";

        public enum Currency { Lira, Usd, Euro, Sterlin }

        public static float usd_sell = 0;
        public static float euro_sell = 0;
        public static float sterlin_sell = 0;

        public static void GetCurrencyValues()
        {
            var cxml = new XmlDocument();
            cxml.Load(exchange);

            string usd_sellstr = cxml.SelectSingleNode("Tarih_Date/Currency [@Kod = 'USD']/BanknoteSelling").InnerXml;
            string euro_sellstr = cxml.SelectSingleNode("Tarih_Date/Currency [@Kod = 'EUR']/BanknoteSelling").InnerXml;
            string sterlin_sellstr = cxml.SelectSingleNode("Tarih_Date/Currency [@Kod = 'GBP']/BanknoteSelling").InnerXml;

            usd_sell = float.Parse(usd_sellstr);
            euro_sell = float.Parse(euro_sellstr);
            sterlin_sell = float.Parse(sterlin_sellstr);        
        }

        public static void HandleCurrencyExchange(BalanceRequest balanceRequest)
        {
            if(balanceRequest.CurrencyType == Currency.Lira)
            {
                ProgramManager.waitingBalanceRequests.Add(balanceRequest);
            }
            if(balanceRequest.CurrencyType == Currency.Usd)
            {
                balanceRequest.Amount = balanceRequest.Amount * usd_sell;
            }
            if (balanceRequest.CurrencyType == Currency.Euro)
            {
                balanceRequest.Amount = balanceRequest.Amount * euro_sell;
            }
            if (balanceRequest.CurrencyType == Currency.Sterlin)
            {
                balanceRequest.Amount = balanceRequest.Amount * sterlin_sell;
            }
            ProgramManager.waitingBalanceRequests.Add(balanceRequest);
        }
    }
}
