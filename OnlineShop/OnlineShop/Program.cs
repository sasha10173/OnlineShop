using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OnlineShop
{
    class Program
    {
        static Corporation corporation = new Corporation();
        static List<Banks> banks = new List<Banks>()
        {
            new Banks("JPMorgan Chase", 2),
            new Banks("Bank of America", 3),
            new Banks("Wells Fargo Chase", 5)
        };

       

        static void LendingRules()
        {
            int LeftIndent = 22;
            int UpIndent = 2;
            Console.Clear();
            Console.SetCursorPosition(LeftIndent, UpIndent++);
            Console.WriteLine($"The percentage of the company is added to the cost of the car, which is {corporation.LoanInterest}%.");
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
        static void Main(string[] args)
        {
            #region Json
            string PatchJson = "AutoModels.json";
            var rootobject = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(PatchJson));
            #endregion

            List<Model> ModelList = new List<Model>();
            for (int i = 0; i < rootobject.Models.Length; i++)
            {
                ModelList.Add(rootobject.Models[i]);
            }

            #region Opening Talk
            
            Console.WriteLine($"-Hello, welcome to the {corporation.Name}");
            Console.WriteLine("My name is August Horch");
            Console.WriteLine("How can I call you?");
            Console.Write("-You can call me: ");
            string Name = Console.ReadLine();

            Buyer buyer = new Buyer(Name);
                #endregion

            while(true)
            {
                Console.WriteLine($"-{Name}, What would you like to see?");

                Console.WriteLine(" 1. The lineup.");
                Console.WriteLine(" 2. Auto in stock.");
                Console.WriteLine(" 3. Lending rules.");

                Console.Write("-I would like to see: ");
                int chose = Convert.ToInt32(Console.ReadLine());
                if (chose == 3)
                {
                    LendingRules();
                }
            }
            
        }
    }
}
