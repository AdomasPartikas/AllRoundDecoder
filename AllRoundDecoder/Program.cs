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
        public static string option;

        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Brain();
        }
        private void StartingLines()
        {
            Console.WriteLine("Welcome to decipher bot.\n"+
                "Choose type of decription: \n"+"1)Morse\n"+
                "2)WD(.Absolute,.Strict)");
            option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    {
                        Console.Write("Please input text: ");
                        inputText = Console.ReadLine();
                        Console.WriteLine(MorseDecode.Morse(inputText));
                    }
                    break;
                case "2":
                    {
                        Console.WriteLine("1)Strict (word is made out of only these letters)\n" + 
                            "2)Absolute (word could have repeating letters *Takes longer*)");
                        option = Console.ReadLine();
                        switch (option)
                        {
                            case "1":
                                {
                                    Console.Write("Please input text: ");
                                    inputText = Console.ReadLine();
                                    option = "s";
                                    WD.WDInitialization(inputText, option);
                                }
                                break;
                            case "2":
                                {
                                    Console.Write("Please input text: ");
                                    inputText = Console.ReadLine();
                                    option = "a";
                                    WD.WDInitialization(inputText, option);
                                }
                                break;
                            default:
                                break;
                        }
                    }break;
                default:
                    {
                        Console.Clear();
                        StartingLines();
                    }break;
            }

        }
        private void Brain()
        {
            StartingLines();
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
