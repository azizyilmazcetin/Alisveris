using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODEV
{
    class SellOrder
    {

        public string SellerMail { get; set; }

        public float Amount { get; set; }

        public float Cost { get; set; }

        public Items.ItemsForSale Item { get; set; }

        public float initialCost { get; set; }
        
        public SellOrder(string sellerMail, float amount, float cost, Items.ItemsForSale item)
        {
            this.SellerMail = sellerMail;
            this.Amount = amount;
            this.Cost = cost;
            this.Item = item;
            this.initialCost = amount * cost;
        }

        public override string ToString()
        {
            return string.Format("SellerMail: {0} \nKg: {1} \nCost: {2} \nItem: {3} \nInitialCost: {4}", this.SellerMail, this.Amount, this.Cost, this.Item, this.initialCost);
        }
    }
}
