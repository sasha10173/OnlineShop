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
    }
}
