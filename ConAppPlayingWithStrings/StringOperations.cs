using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithStrings
{
    internal class StringOperations
    {
        public  string VowelsString()
        {
            var strArr = "kaliningrad";  //aeoui  //result=> kaliningrad

            var res = new StringBuilder();
            for (int start = 0, end = strArr.Length - 1; start < strArr.Length; start++)
            {
                if ("aeouiAEOUI".IndexOf(strArr[start]) < 0)
                 {
                    res.Append(strArr[start]);
                }
                else
                {
                    while (end > 0 && "aeouiAEOUI".IndexOf(strArr[end]) < 0)
                    {
                        end--;
                    }
                    res.Append(strArr[end]);
                    end--;
                }
            }
            return res.ToString();
        }

        private static void StrStats() //a dictionary of char key and number of reoccuring characters;
        {
            var strArr = "aabbbccccddddd";
            var stats = new Dictionary<char, int>();
            var strCounter = 0;
            foreach (var item in strArr)
            {
                if (!stats.Keys.Contains(item))
                {
                    strCounter = 0;
                    stats.Add(item, ++strCounter);
                }
                else
                {
                    stats[item] = ++strCounter;
                }
            }
        }

    }
}
