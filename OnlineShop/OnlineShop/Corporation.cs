using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop
{
    class Corporation
    {
        public string Name { get; set; }
        public int LoanInterest { get; set; }
        public Corporation()
        {
            LoanInterest = 3;
            Name = "Audi Corporation";
        }
    }
}
