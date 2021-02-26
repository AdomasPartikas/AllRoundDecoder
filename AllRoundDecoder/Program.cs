using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace AllRoundDecoder
{
    public class Program
    {
        public static string inputText;

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Brain();
        }
        private void StartingLines()
        {
            Console.WriteLine("Welcome to decipher bot.");
            Console.Write("Please input a text: ");
            var text = Console.ReadLine();
            inputText = text.ToLower();
            Console.WriteLine(inputText);
        }
        private void Brain()
        {
            StartingLines();
            Console.WriteLine(MorseDecode.Morse(inputText));
            //WD.WDInitialization(inputText);
            Console.ReadKey();
        }

        //private string ScramblerTest()
        //{
        //    char[] charArray = inputText.ToArray();
        //    Random r = new Random(300);
        //    char temp;
        //    int index;

        //    for (int i = 0; i < charArray.Length; i++)
        //    {
        //        index = r.Next(0, charArray.Length);
        //        temp = charArray[index];
        //        charArray[index] = charArray[i];
        //        charArray[i] = temp;
        //    }
        //    string finished = new string(charArray);


        //    return finished;
        //}
    }
}
