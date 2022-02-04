using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop
{
    class Banks
    {
        public string Name { get; set; }
        public int LoanInterest { get; set; }
        public Banks(string Name, int LoanInterest)
        {
            this.Name = Name;
            this.LoanInterest = LoanInterest;
        }

        public int FullCost(int Price ,int PercentCor)
        {
            double proc = ((double)LoanInterest / 10) + ((double)PercentCor / 10);
            double remainder = (Price * proc) / 10;
            int sum = Price + (int)remainder;
            return sum;
        }
    }
}
