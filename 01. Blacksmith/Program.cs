using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;

namespace _01._Blacksmith
{
    public class Program
    {
        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Queue<double> steel = new Queue<double>(Console.ReadLine()
                .Split()
                .Select(double.Parse));

            Stack<double> carbon = new Stack<double>(Console.ReadLine()
                .Split()
                .Select(double.Parse));

            Dictionary<string, int> blacksmith = new Dictionary<string, int>
            {
                { "Gladius", 0 },
                { "Shamshir", 0 },
                { "Katana", 0},
                { "Sabre", 0},
                { "Broadsword", 0}
            };

            while (carbon.Any() && steel.Any())
            {
                double mix = steel.Peek() + carbon.Peek();


                if (mix == 70)
                {
                    blacksmith["Gladius"]++;
                    steel.Dequeue();
                    carbon.Pop();

                }
                else if (mix == 80)
                {
                    blacksmith["Shamshir"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (mix == 90)
                {
                    blacksmith["Katana"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (mix == 110)
                {
                    blacksmith["Sabre"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (mix == 150)
                {
                    blacksmith["Broadsword"]++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    double tempCarbon = carbon.Pop() + 5;
                    carbon.Push(tempCarbon);
                }
                
            }
            if (blacksmith.Values.Any(x => x != 0))
            {
                Console.WriteLine($"You have forged {blacksmith.Values.Sum()} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (!steel.Any())
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            if (!carbon.Any())
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            foreach (var sword in blacksmith.OrderBy(x => x.Key))
            {
                if (sword.Value > 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
