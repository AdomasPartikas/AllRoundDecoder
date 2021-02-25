using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Text.RegularExpressions;

namespace AllRoundDecoder
{
    public class Program
    {
        private static Dictionary<string, char> _morseAlphabet;
        public static string inputText;
        public static int permutations = 0;
        public static int correctPermutations = 0,xTemp=0;
        public List<string> correctWordList = new List<string>();
        public List<string> similarWords = new List<string>();
        DateTime timeStarted;

        Microsoft.Office.Interop.Word.Application appWord =
            new Microsoft.Office.Interop.Word.Application();
        public static void Main(string[] args)
        {
            Program p = new Program();
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
            StartingLines();
            Console.WriteLine(ScramblerTest());
            //Console.ReadKey();
            //if (IsWordCorrect(ScramblerTest()))
            //    Console.WriteLine("correct");
            //else
            //    Console.WriteLine("incorrect");
            //if (IsWordCorrect(inputText))
            //    Console.WriteLine("correct");
            //else
            //    Console.WriteLine("incorrect");
            //Console.ReadKey();
            Console.WriteLine();
            StartingLines();
            WordDescrambler(inputText);
            Console.ReadKey();
        }


        private string ScramblerTest()
        {
            char[] charArray = inputText.ToArray();
            Random r = new Random(300);
            char temp;
            int index;

            for (int i = 0; i < charArray.Length; i++)
            {
                index = r.Next(0, charArray.Length);
                temp = charArray[index];
                charArray[index] = charArray[i];
                charArray[i] = temp;
            }
            string finished = new string(charArray);


            return finished;
        }
        private void WordDescrambler(string word)
        {
            //char[] arr = word.ToArray();
            timeStarted = DateTime.Now;
            int max = word.Length;
            correctPermutations = 0;
            xTemp=0;
            DisplayWordDescrambler();
            Dive("", 0, word, max);


            Console.WriteLine("Words created. - {0}", DateTime.Now.ToString());
            Console.WriteLine("Time passed: {0}s", DateTime.Now.Subtract(timeStarted).TotalSeconds);

            //foreach (var item in correctWordList)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine("correct permutations: " + $"{correctPermutations}");
            Console.WriteLine("total permutations: " + $"{permutations}");


            Console.ReadKey();
        }
        private void Dive(string prefix, int level, string ValidChars, int max)
        {
            level += 1;
            foreach (char c in ValidChars)
            {
                permutations++;
                if ((prefix + c).Length == max)
                {
                    Console.WriteLine(prefix + c);
                    if (IsWordCorrect(prefix + c))
                    {
                        if (!correctWordList.Contains(prefix + c))
                        {
                           correctWordList.Add(prefix + c);
                        }
                        correctPermutations++;
                        //DisplayWordDescrambler();
                    }
                }
                if (permutations==xTemp+100)
                {
                    xTemp += 100;
                    //DisplayWordDescrambler();
                }
                if (level < max)
                {
                    Dive(prefix + c, level, ValidChars, max);
                }
            }
        }
        private void DisplayWordDescrambler()
        {
            Console.Clear();
            Console.WriteLine("Working............ - {0}", timeStarted.ToString());
            Console.WriteLine("Correct permutations: " + $"{correctPermutations}");
            Console.WriteLine("Total permutations: " + $"{permutations}");
            Console.WriteLine();
            Console.WriteLine("Words created: ");

            foreach (var item in correctWordList)
            {
                Console.WriteLine(item);
            }
        }
        private bool IsWordCorrect(string word)
        {
            return appWord.CheckSpelling(word);
        }
        private string Morse()
        {
            var c = inputText.Split(' ').ToList();

            for (int i = 0; i < c.Count; i++)
            {
                c[i] = c[i].Replace(".", ".");
                c[i] = c[i].Replace("*", ".");
                c[i] = c[i].Replace("-", "-");
                c[i] = c[i].Replace("_", "-");
            }

            InitializeDictionary();
            StringBuilder output = new StringBuilder();
            foreach (string item in c)
            {
                if (_morseAlphabet.ContainsKey(item))
                    output.Append(_morseAlphabet[item]);
                else if (item == "/" || item == "|")
                    output.Append(" ");
            }

            return (output.ToString());

        }
        private void InitializeDictionary()
        {
            _morseAlphabet = new Dictionary<string, char>()
                                   {
                                       {".-",'a'},
                                       {"-...",'b'},
                                       {"-.-.",'c'},
                                       {"-..",'d'},
                                       {".",'e'},
                                       {"..-.",'f'},
                                       {"--.",'g'},
                                       {"....",'h'},
                                       {"..",'i'},
                                       {".---",'j'},
                                       {"-.-",'k'},
                                       {".-..",'l'},
                                       {"--",'m'},
                                       {"-.",'n'},
                                       {"---",'o'},
                                       {".--.",'p'},
                                       {"--.-",'q'},
                                       {".-.",'r'},
                                       {"...",'s'},
                                       {"-",'t'},
                                       {"..-",'u'},
                                       {"...-",'v'},
                                       {".--",'w'},
                                       {"-..-",'x'},
                                       {"-.--",'y'},
                                       {"--..",'z'},
                                       {"-----",'0'},
                                       {".----",'1'},
                                       {"..---",'2'},
                                       {"...--",'3'},
                                       {"....-",'4'},
                                       {".....",'5'},
                                       {"-....",'6'},
                                       {"--...",'7'},
                                       {"---..",'8'},
                                       {"----.",'9'}
                                   };
        }
    }
}
