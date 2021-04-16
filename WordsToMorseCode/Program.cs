using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsToMorseCode
{
    class Program
    {
        private static string[] Morse = new String[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
        static void Main(string[] args)
        {
            try
            {
                var words = new string[] { "gin", "zen", "gig", "msg" };
                var morseCodes = new HashSet<string>();
                foreach (var word in words)
                {
                    morseCodes.Add(WordToMorse(word));
                }
                Console.WriteLine(string.Format("Distinct morse codes = {0}", morseCodes.Count));
                Console.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string WordToMorse(string word)
        {
            var retVal = new StringBuilder();

            foreach (var character in word.ToCharArray())
            {
                var index = (int)character - 97;
                var morse = Morse[index];
                retVal.Append(morse);
            }

            return retVal.ToString();
        }
    }
}
