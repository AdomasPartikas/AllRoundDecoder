using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllRoundDecoder
{
    public class Program
    {
        public static string inputText;
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to decipher bot.");
            Console.Write("Please input a text: ");
            inputText = Console.ReadLine();
            Console.WriteLine(inputText);
            Console.ReadKey();
        }
    }
}
