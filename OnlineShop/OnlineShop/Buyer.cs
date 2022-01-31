using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop
{
    class Buyer
    {
        public string Name { get; set; }
        public int Balance { get; set; }
        


        public Buyer(string Name, int balance)
        {
            this.Name = Name;
            Balance = balance;
        }
    }
}
