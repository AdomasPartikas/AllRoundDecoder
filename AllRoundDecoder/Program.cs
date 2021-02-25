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
        private static Dictionary<string, char> _morseAlphabet;
        public static string inputText;
        public static int permutations = 0;
        public static int correctPermutations = 0, xCount;
        public List<string> correctWordList = new List<string>();
        DateTime timeStarted;
        public static double timeRemainder;

        public static Microsoft.Office.Interop.Word.Application appWord =
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
            var text = Console.ReadLine();
            inputText = text.ToLower();
            Console.WriteLine(inputText);
        }
        private void Brain()
        {
            StartingLines();
            WDInitialization(inputText);
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
        private void WDInitialization(string word)
        {
            List<string> temp = new List<string>();

            temp = word.Split(' ').ToList();

            timeStarted = DateTime.Now;

            for (int i = 0; i < temp.Count; i++)
            {
                int max = temp[i].Length;
                xCount = 0;
                Console.Clear();
                WDProcess("", 0, temp[i], max);
            }

            appWord.Quit();
        }
        private void WDProcess(string prefix, int level, string ValidChars, int max)
        {
            level += 1;
            foreach (char c in ValidChars)
            {
                if (level < max)
                {
                    WDProcess(prefix + c, level, ValidChars, max);
                }
                if ((prefix + c).Length == max)
                {
                    permutations++;
                    if (appWord.CheckSpelling(prefix + c))
                    {
                        if (!correctWordList.Contains(prefix + c))
                        {
                            correctWordList.Add(prefix + c);
                            DisplayWordDescrambler(max);
                        }
                        correctPermutations++;
                    }
                    else if (permutations >= xCount + 1000)
                    {
                        if (permutations==1000)
                        {
                            timeRemainder = DateTime.Now.Subtract(timeStarted).TotalSeconds;
                        }
                        xCount += 1000;
                        DisplayWordDescrambler(max);
                    }
                }
            }
        }
        private void DisplayWordDescrambler(int max)
        {
            Console.Clear();
            Console.WriteLine("Word descrambler initialized. \n" + "Starting time - {0}", timeStarted.ToString());
            Console.WriteLine("Time passed: {0}s", DateTime.Now.Subtract(timeStarted).TotalSeconds);
            Console.WriteLine("Time remaining: {0}",CalculateRemainingTime(max));
            Console.WriteLine("\nBe patient!\n" + "\nCorrect permutations: " + $"{correctPermutations}\n" + "Permutation Count: " + $"{permutations}\n" + "\nWords created:");
            foreach (var item in correctWordList)
            {
                Console.WriteLine(item);
            }
        }
        private bool IsWordCorrect(string word)
        {
            return appWord.CheckSpelling(word);
        }
        private string CalculateRemainingTime(int integer)
        {
            string remaining = "{0}h:{0}m:{0}s:{0}ms";
            double temp;
            switch (integer)
            {
                case 5:
                    {
                        temp = ((3125 - permutations) / 1000) * timeRemainder;

                        TimeSpan x = TimeSpan.FromSeconds(temp);
                        remaining = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", x.Hours, x.Minutes, x.Seconds, x.Milliseconds);
                        return remaining;
                    }

                case 6:
                    {
                        //One of the formulas that i used, not precise, doesn't work
                        //if (permutations >= 23328)
                        //    temp = (elapsed / (100 - ((46656 - permutations) / 46656 * 100))) * (46656 - permutations) / 46656 * 100;
                        //else
                        //    temp = elapsed * (46656 / permutations);  //works at the end, when there is 20secs left

                        temp = ((46656 - permutations) / 1000) * timeRemainder;

                        TimeSpan x = TimeSpan.FromSeconds(temp);
                        remaining = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", x.Hours, x.Minutes, x.Seconds);
                        return remaining;
                    }
                case 7:
                    {
                        temp = ((823543 - permutations) / 1000) * timeRemainder;

                        TimeSpan x = TimeSpan.FromSeconds(temp);
                        remaining = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", x.Hours, x.Minutes, x.Seconds);
                        return remaining;
                    }
                case 8:
                    {
                        temp = ((16777216 - permutations) / 1000) * timeRemainder;

                        TimeSpan x = TimeSpan.FromSeconds(temp);
                        remaining = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", x.Hours, x.Minutes, x.Seconds);
                        return remaining;
                    }
                case 9:
                    {
                        temp = ((387420489 - permutations) / 1000) * timeRemainder;

                        TimeSpan x = TimeSpan.FromSeconds(temp);
                        remaining = string.Format("{0:D2}d:{1:D2}h:{2:D2}m:{3:D2}s",x.Days, x.Hours, x.Minutes, x.Seconds);
                        return remaining;
                    }
                default:
                    {
                        return remaining;
                    }
            }
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
