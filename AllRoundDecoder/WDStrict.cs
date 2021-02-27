using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllRoundDecoder
{
    public class WDStrict
    {
        public static int permutations = 0;
        private static int correctPermutations = 0, xCount = 0;
        private static List<string> correctWordList = new List<string>();

        private static DateTime timeStarted;

        private static Microsoft.Office.Interop.Word.Application appWord =
                    new Microsoft.Office.Interop.Word.Application();

        private static double timeRemainder;

        public static void WDStrictInitialization(char[] str,int index,int n)
        {
            timeStarted = DateTime.Now;
            FindPermutations(str, index, n);
            DWDStrict(0);
            appWord.Quit();
        }
        static bool ShouldSwap(char[] str,int start, int curr)
        {
            for (int i = start; i < curr; i++)
            {
                if (str[i] == str[curr])
                {
                    return false;
                }
            }
            return true;
        } 
        public static void FindPermutations(char[] str,int index, int n)
        {
            if (index >= n)
            {
                permutations++;
                if (permutations >= xCount + 200)
                {
                    if (permutations == 200)
                    {
                        timeRemainder = DateTime.Now.Subtract(timeStarted).TotalSeconds;
                    }
                    xCount += 200;
                    DWDStrict(n);
                }
                StringBuilder stringBuilder = new StringBuilder();
                foreach (char c in str)
                {
                    stringBuilder.Append(c);
                }

                if (appWord.CheckSpelling(stringBuilder.ToString()))
                {
                    correctPermutations++;
                    correctWordList.Add(stringBuilder.ToString());
                }
                return;
            }

            for (int i = index; i < n; i++)
            {
                bool check = ShouldSwap(str, index, i);
                if (check)
                {
                    Swap(str, index, i);
                    FindPermutations(str, index + 1, n);
                    Swap(str, index, i);
                }
            }
        }
        static void Swap(char[] str, int i, int j)
        {
            char c = str[i];
            str[i] = str[j];
            str[j] = c;
        }
        public static void DWDStrict(int integer)
        {
            Console.Clear();
            if (integer == 0)
                Console.WriteLine("Finished!..");
            else
                Console.WriteLine("Word Descrambler Strict initialized... \n" + "Starting time - {0}", timeStarted.ToString());
            Console.WriteLine("Time passed: {0}s", DateTime.Now.Subtract(timeStarted).TotalSeconds);
            Console.WriteLine("Time remaining: {0}", CRTStrict(integer));
            Console.WriteLine("\nCorrect permutations: " + $"{correctPermutations}\n" + "Total Permutation Count: " + $"{permutations}\n" + "\nWords built:");
            foreach (var item in correctWordList)
            {
                Console.WriteLine(item);
            }
        }
        private static string CRTStrict(int integer)
        {
            string remaining = "00h:00m:00s:00ms";
            double temp;
            switch (integer)
            {
                case 6:
                    {
                        temp = ((720 - permutations) / 200) * timeRemainder;

                        TimeSpan x = TimeSpan.FromSeconds(temp);
                        remaining = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", x.Hours, x.Minutes, x.Seconds);
                        return remaining;
                    }
                case 7:
                    {
                        temp = ((5040 - permutations) / 200) * timeRemainder;

                        TimeSpan x = TimeSpan.FromSeconds(temp);
                        remaining = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", x.Hours, x.Minutes, x.Seconds);
                        return remaining;
                    }
                case 8:
                    {
                        temp = ((40320 - permutations) / 200) * timeRemainder;

                        TimeSpan x = TimeSpan.FromSeconds(temp);
                        remaining = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", x.Hours, x.Minutes, x.Seconds);
                        return remaining;
                    }
                case 9:
                    {
                        temp = ((362880 - permutations) / 200) * timeRemainder;

                        TimeSpan x = TimeSpan.FromSeconds(temp);
                        remaining = string.Format("{0:D2}d:{1:D2}h:{2:D2}m:{3:D2}s", x.Days, x.Hours, x.Minutes, x.Seconds);
                        return remaining;
                    }
                case 10:
                    {
                        temp = ((3628800 - permutations) / 200) * timeRemainder;

                        TimeSpan x = TimeSpan.FromSeconds(temp);
                        remaining = string.Format("{0:D2}d:{1:D2}h:{2:D2}m:{3:D2}s", x.Days, x.Hours, x.Minutes, x.Seconds);
                        return remaining;
                    }
                case 11:
                    {
                        temp = ((39916800 - permutations) / 200) * timeRemainder;

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
