using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODEV
{
    class BuyOrder
    {
        public string BuyerMail { get; set; }

        public float Amount { get; set; }

        public float Cost { get; set; }

        public Items.ItemsForSale Item { get; set; }

        public float initialCost { get; set; }

        public BuyOrder(string buyerMail, float amount, float cost, Items.ItemsForSale item)
        {
            this.BuyerMail = buyerMail;
            this.Amount = amount;
            this.Cost = cost;
            this.Item = item;
            this.initialCost = amount * cost;
        }

        public override string ToString()
        {
            return string.Format("BuyerMail: {0} \nKg: {1} \nCost: {2} \nItem: {3} \nInitialCost: {4}", this.BuyerMail, this.Amount, this.Cost, this.Item, this.initialCost);
        }
    }
}
