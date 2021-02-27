using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllRoundDecoder
{
    class MorseDecode
    {
        private static Dictionary<string, char> _morseAlphabet;
        public static string Morse(string inputText)
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
                else
                    output.Append("#");
            }

            return (output.ToString());

        }
        private static void InitializeDictionary()
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
