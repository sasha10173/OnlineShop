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

        private int FullCost(int Price ,int Percent)
        {
            int proc = (LoanInterest / 10) + (Percent / 10);
            int remainder = (Price * proc) / 100;
            int sum = Price + remainder;
            return sum;
        }
    }
}
