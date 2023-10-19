using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _04._Food_Finder
{
    public class Program
    {
        static void Main(string[] args)
        {

            Queue<char> vowels = new Queue<char>(Console.ReadLine().Replace(" ",""));

            Stack<char> consonants = new Stack<char>(Console.ReadLine().Replace(" ", ""));
                

            Dictionary<string, char[]> words = new Dictionary<string, char[]>
            {
                { "pear", "pear".ToCharArray()},
                { "flour", "flour".ToCharArray() },
                { "pork", "pork".ToCharArray()},
                { "olive", "olive".ToCharArray()}
            };
           
            while (consonants.Any())
            {
                char currentVowelsChar = (char)vowels.Dequeue();
                char currentConsonantsChar = (char)consonants.Pop();

                var newPear = words["pear"].Where(x => x != currentVowelsChar).Where(x => x != currentConsonantsChar).ToArray();
                words["pear"] = newPear;

                var newFlour = words["flour"].Where(x => x != currentVowelsChar).Where(x => x != currentConsonantsChar).ToArray();

                words["flour"] = newFlour;

                var newPork = words["pork"].Where(x => x != currentVowelsChar).Where(x => x != currentConsonantsChar).ToArray();

                words["pork"] = newPork;

                var newOlive = words["olive"].Where(x => x != currentVowelsChar).Where(x => x != currentConsonantsChar).ToArray();
                words["olive"] = newOlive;

                vowels.Enqueue(currentVowelsChar);
            }
            
            foreach (var word in words)
            {
                if (word.Value.Length > 0)
                {
                    words.Remove(word.Key);
                }
            }
            Console.WriteLine($"Words found: {words.Count}");
            Console.WriteLine($"{string.Join("\n", words.Keys)}");
        }
    }
}
