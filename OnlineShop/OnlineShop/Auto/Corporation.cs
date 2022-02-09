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

        public int SellCar(int price, int balance)
        {
            bool exit = true;
            while (exit)
            {


                Console.Clear();
                int chose = 0;
                if (balance >= price)
                {
                    Console.WriteLine($"Your balance is {balance}$, the price of the car is {price}$," +
                        $" you have enough funds, you can buy a car right now.");
                    Console.WriteLine("Your Choice");
                    Console.WriteLine("1. I buy a car.");
                    Console.WriteLine("2. I changed my mind.");
                    Console.Write("Your choice: ");

                    try
                    {
                        chose = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You entered incorrect data, please try again.");
                        Console.WriteLine("Please press enter.");
                        Console.ReadLine();
                        continue;
                    }
                    if (chose < 1 | chose > 2)
                    {
                        Console.WriteLine("You entered incorrect data, please try again.");
                        Console.WriteLine("Please press enter.");
                        Console.ReadLine();
                        continue;
                    }

                    return chose;
                }
                else if (balance < price)
                {

                    Console.WriteLine($"Your balance is {balance}$, the price of the car is {price}$, alas," +
                        $" you do not have enough funds, but you can get a loan.");
                    Console.WriteLine("Your Choice");
                    Console.WriteLine("1. I will take a loan.");
                    Console.WriteLine("2. I changed my mind.");
                    Console.Write("Your choice: ");

                    try
                    {
                        chose = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You entered incorrect data, please try again.");
                        Console.WriteLine("Please press enter.");
                        Console.ReadLine();
                        continue;
                    }
                    if (chose <= 0 | chose >= 3)
                    {
                        Console.WriteLine("You entered incorrect data, please try again.");
                        Console.WriteLine("Please press enter.");
                        Console.ReadLine();
                        continue;
                    }
                    return chose;
                }
            }
            return 0;
        }
    }
}
