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
            Program p = new Program();
            p.StartingLines();
            p.Brain();
        }

        private void StartingLines()
        {
            Console.WriteLine("Welcome to decipher bot.");
            Console.Write("Please input a text: ");
            inputText = Console.ReadLine();
            Console.WriteLine(inputText);
        }

        private void Brain()
        {

        }
    }
}
