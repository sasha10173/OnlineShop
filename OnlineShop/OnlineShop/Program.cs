using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OnlineShop
{
    class Program
    {
        static Random rnd = new Random();
        static Corporation Audi = new Corporation();
        static List<Model> ModelList = new List<Model>();
        static List<Equipment> AutoInStock = new List<Equipment>();
        static List<Banks> banks = new List<Banks>()
        {
            new Banks("JPMorgan Chase", 12),
            new Banks("Bank of America", 13),
            new Banks("Wells Fargo Chase", 15)
        };     

        static void LendingRules()
        {
            int LeftIndent = 22;
            int UpIndent = 2;
            Console.Clear();
            Console.SetCursorPosition(LeftIndent, UpIndent++);
            Console.WriteLine($"The percentage of the company is added to the cost of the car, which is {Audi.LoanInterest}%.");
            Console.SetCursorPosition(LeftIndent, UpIndent++);
            Console.WriteLine("Plus, the percentage of the bank that you choose is added to this.");
            for (int i = 0; i < banks.Count; i++)
            {
                Console.SetCursorPosition(LeftIndent, UpIndent++);
                Console.WriteLine($"Bank's name: {banks[i].Name}, Bank Percentage: {banks[i].LoanInterest}%.");
            }
            Console.ReadLine();
            Console.Clear();
        }
        static void LineUp()
        {
            int chose = 0;
            bool exit = true;
            while (exit)
            {
                int modelNumber = 0;
                Console.Clear();

                foreach (var item in ModelList)
                {
                    Console.WriteLine($"{modelNumber++}. {item.NameModel}");
                    Console.WriteLine(item.Description);
                    Console.WriteLine("---------------------");
                }
                Console.WriteLine();
                Console.WriteLine("Which model would you like to see in more detail?\n");
                Console.WriteLine("(*Enter number*)");
                Console.Write("I would like to see the model: ");

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
                if (chose < 0 | chose > (ModelList.Count-1))
                {
                    Console.WriteLine("You entered incorrect data, please try again.");
                    Console.WriteLine("Please press enter.");
                    Console.ReadLine();
                    continue;
                }
                exit = false;
            }

            Console.Clear();

            foreach (var item in ModelList[chose].Equipment)
            {
                Console.WriteLine($"Name model: {item.Model}");
                Console.WriteLine($"Engine: {item.Engine}");
                Console.WriteLine($"Horse Power: {item.Horsepower}");
                Console.WriteLine($"Cplor: {item.Color}");
                Console.WriteLine($"Prise: {item.Price}$");
                Console.WriteLine($"Availability: {item.IsAvailable}");
                Console.WriteLine("--------------");
            }
            Console.ReadLine();
        }
        static int InStock()
        {           
            bool exit = true;
            int chose = 0;
            while (exit)
            {
                int number = 0;
                Console.Clear();
                for (int i = 0; i < ModelList.Count; i++)
                {
                    for (int k = 0; k < ModelList[i].Equipment.Length; k++)
                    {
                        if (ModelList[i].Equipment[k].IsAvailable == true)
                        {
                            AutoInStock.Add(ModelList[i].Equipment[k]);
                            Console.WriteLine(number++ + "");
                            Console.WriteLine("Model: " + ModelList[i].Equipment[k].Model);
                            Console.WriteLine("Engine: " + ModelList[i].Equipment[k].Engine);
                            Console.WriteLine("Prise: " + ModelList[i].Equipment[k].Price + "$");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("-----------");
                }
                Console.WriteLine("What car do you want to buy?");
                Console.WriteLine("(*Enter number*)");

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
                if (chose < 0 | chose > (AutoInStock.Count - 1))
                {
                    Console.WriteLine("You entered incorrect data, please try again.");
                    Console.WriteLine("Please press enter.");
                    Console.ReadLine();
                    continue;
                }
                exit = false;
            }
            return chose;
        }

        static void CreditOn(int price)
        {
            bool exit = true;
            while (exit)
            {
                int Chose = 0;
                Console.Clear();
                int randomBank = rnd.Next(banks.Count);
                Console.WriteLine($"When considering your application you agreed to give a loan to only one bank *{banks[randomBank].Name}*, " +
                    $"The banks interest is {banks[randomBank].LoanInterest}%");
                int FullPrice = banks[randomBank].FullCost(price, Audi.LoanInterest);
                Console.WriteLine($"The full coast purchase: {FullPrice}$ ");
                Console.WriteLine("Please confirm purchase.");
                Console.WriteLine("1. I agree.");
                Console.WriteLine("2. I disagree.");
                Console.WriteLine("(*Enter the number.*)");
                Console.Write("Your choise: ");

                try
                {
                    Chose = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("You entered incorrect data, please try again.");
                    Console.WriteLine("Please press enter.");
                    Console.ReadLine();
                    continue;
                }
                switch (Chose)
                {
                    case 1:
                        Console.WriteLine("Great, here are your keys, you can drive away in a brand new Audi.");
                        Console.WriteLine("All the best, we are always waiting for you in our store.");
                        exit = false;
                        break;
                    case 2:
                        Console.WriteLine("All the best, we are always waiting for you in our store.");
                        exit = false;
                        break;

                    default:
                        Console.WriteLine("You entered incorrect data, please try again.");
                        Console.WriteLine("Please press enter.");
                        Console.ReadLine();                 
                        break;
                }
            }
        }

        static bool BuyCar(int chose, int balance)
        {
            Console.Clear();
            Console.WriteLine($"You want to buy ");
            Console.WriteLine($"Name model: {AutoInStock[chose].Model}");
            Console.WriteLine($"Engine: {AutoInStock[chose].Engine}");
            Console.WriteLine($"Horse Power: {AutoInStock[chose].Horsepower}");
            Console.WriteLine($"Color: {AutoInStock[chose].Color}");
            Console.WriteLine($"Prise: {AutoInStock[chose].Price}$");
            int BuyOrNot = Audi.SellCar(int.Parse(AutoInStock[chose].Price), balance);
            if (BuyOrNot == 1)
            {
                if (balance>= int.Parse(AutoInStock[chose].Price))
                {
                    Console.WriteLine("Great, here are your keys, you can drive away in a brand new Audi.");
                    return false;
                }
                else if (balance < int.Parse(AutoInStock[chose].Price))
                {
                    CreditOn(int.Parse(AutoInStock[chose].Price));
                    return false;
                }
            }
            else if (BuyOrNot == 2)
            {
                Console.WriteLine("All the best, we are always waiting for you in our store.");
                return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            #region Json
            string PatchJson = "AutoModels.json";
            var rootobject = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(PatchJson));
            #endregion
            
            for (int i = 0; i < rootobject.Models.Length; i++)
            {
                ModelList.Add(rootobject.Models[i]);
            }

            #region Opening Talk
            
            Console.WriteLine($"-Hello, welcome to the {Audi.Name}");
            Console.WriteLine("My name is August Horch");
            Console.WriteLine("How can I call you?");
            Console.Write("-You can call me: ");
            string Name = Console.ReadLine();

            Buyer buyer = new Buyer(Name, 45700);
            #endregion

            bool exit = true;

            while(exit)
            {
                Console.Clear();
                Console.WriteLine($"-{Name}, What would you like to see?");

                Console.WriteLine(" 1. The lineup.");
                Console.WriteLine(" 2. Auto in stock.");
                Console.WriteLine(" 3. Lending rules.");

                Console.Write("-I would like to see: ");
                int chose = 0;
                try
                {
                chose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("You entered incorrect data, please try again.");
                    Console.WriteLine("Please press enter.");
                    Console.ReadKey();
                    continue;
                }

                if (chose < 1 | chose > 3 )
                {
                    Console.WriteLine("You entered incorrect data, please try again.");
                    Console.WriteLine("Please press enter.");
                    Console.ReadLine();
                    continue;
                }
                
                switch (chose)
                {
                    case 1:
                        LineUp();
                        break;
                    case 2:
                        int numberCar = InStock();
                        exit = BuyCar(numberCar, buyer.Balance);
                        break;
                    case 3:
                        LendingRules();
                        break;
                }

            }
            
        }
    }
}
