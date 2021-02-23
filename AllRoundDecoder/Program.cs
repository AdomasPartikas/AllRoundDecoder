using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AllRoundDecoder
{
    public class Program
    {
        private static Dictionary<string, char> _morseAlphabet;
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
            Console.WriteLine(Morse());
            Console.ReadLine();
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
