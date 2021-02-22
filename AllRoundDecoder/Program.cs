using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllRoundDecoder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputText = "";
            IntroText(inputText);
        }

        private static void IntroText(string code)
        {
            Console.WriteLine("Welcome to decipher bot.");
            Console.Write("Please input a text: ");
            code = Console.ReadLine();
            Console.WriteLine(code);
            Console.ReadKey();
        }
    }
}
