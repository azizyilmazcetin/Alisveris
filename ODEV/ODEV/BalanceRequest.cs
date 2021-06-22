using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODEV
{
    class BalanceRequest
    {
        string Name { get; set; }
        public string Mail { get; set; }
        public float Amount { get; set; } 
        public bool IsApprovedByAdmin { get; set; }
        public CurrencyManager.Currency CurrencyType { get; set; }

        public BalanceRequest(string name,string lastName,string mail, float amount, CurrencyManager.Currency currencyType)
        {
            this.Name = name + " " + lastName;
            this.Mail = mail;
            this.Amount = amount;
            this.CurrencyType = currencyType;
        }

        public override string ToString()
        {
            return string.Format("Name: {0} \nMail: {1} \nAmount: {2} Lira",this.Name, this.Mail, Math.Round(this.Amount, 2));
        }
    }
}
