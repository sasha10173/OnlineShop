using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop
{
    class Buyer
    {
        public string Name { get; set; }
        public decimal Balance
        {
            get
            {
                return Balance;
            }
            set
            {
                Balance = 45700M;
            }
        }


        public Buyer(string Name)
        {
            this.Name = Name;
        }
    }
}
