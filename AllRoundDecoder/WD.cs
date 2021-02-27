using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllRoundDecoder
{
    public class WD
    {
        private static int permutations = 0;
        private static int correctPermutations = 0, xCount = 0;
        private static List<string> correctWordList = new List<string>();

        private static DateTime timeStarted;

        private static Microsoft.Office.Interop.Word.Application appWord =
                    new Microsoft.Office.Interop.Word.Application();

        private static double timeRemainder;

        public static void WDInitialization(string word,string option)
        {
            switch (option)
            {
                case "s":
                    {
                        timeStarted = DateTime.Now;
                        WDStrict.WDStrictInitialization(word.ToCharArray(), 0, word.Length);
                    }
                    break;
                case "a":
                    {
                        timeStarted = DateTime.Now;
                        WDProcessAbsolute("", 0, word, word.Length);
                    }
                    break;
                default:
                    break;
            }
            //List<string> temp = new List<string>();

            //temp = word.Split(' ').ToList();

            //timeStarted = DateTime.Now;

            //for (int i = 0; i < temp.Count; i++)
            //{
            //    int max = temp[i].Length;
            //    xCount = 0;
            //    WDProcessAbsolute("", 0, temp[i], max);
            //}

            //appWord.Quit();
        }
        private static void WDProcessAbsolute(string prefix, int level, string ValidChars, int max)
        {
            level += 1;
            foreach (char c in ValidChars)
            {
                if (level < max)
                {
                    WDProcessAbsolute(prefix + c, level, ValidChars, max);
                }
                if ((prefix + c).Length == max)
                {
                    permutations++;
                    if (appWord.CheckSpelling(prefix + c))
                    {
                        if (!correctWordList.Contains(prefix + c))
                        {
                            correctWordList.Add(prefix + c);
                            DWDAbsolute(max);
                        }
                        correctPermutations++;
                    }
                    else if (permutations >= xCount + 1000)
                    {
                        if (permutations == 1000)
                        {
                            timeRemainder = DateTime.Now.Subtract(timeStarted).TotalSeconds;
                        }
                        xCount += 1000;
                        DWDAbsolute(max);
                    }
                }
            }
        }
        private static void DWDAbsolute(int max)
        {
            Console.Clear();
            if (max == 0)
                Console.WriteLine("Finished!..");
            else
                Console.WriteLine("Word Descrambler Strict initialized... \n" + "Starting time - {0}", timeStarted.ToString());
            Console.WriteLine("Time passed: {0}s", DateTime.Now.Subtract(timeStarted).TotalSeconds);
            Console.WriteLine("Time remaining: {0}", CRTAbsolute(max));
            Console.WriteLine("\nBe patient!\n" + "\nCorrect permutations: " + $"{correctPermutations}\n" + "Total Permutation Count: " + $"{permutations}\n" + "\nWords created:");
            foreach (var item in correctWordList)
            {
                Console.WriteLine(item);
            }
        }
        private static string CRTAbsolute(int integer)
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
                        remaining = string.Format("{0:D2}d:{1:D2}h:{2:D2}m:{3:D2}s", x.Days, x.Hours, x.Minutes, x.Seconds);
                        return remaining;
                    }
                default:
                    {
                        return remaining;
                    }
            }
        }
    }
}
