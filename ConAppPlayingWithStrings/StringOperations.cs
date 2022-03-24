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

        public  void StrStats() //a dictionary of char key and number of reoccuring characters;
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

        //Comparing reversed string
        public bool IsReversedStringTheSame()
        {
            var str = "abba";
            if (!string.IsNullOrEmpty(str))
            {
                return str.SequenceEqual(str.Reverse());
            }
            return false;
        }

        //Reverse words in the string
        public string ReverseWordsInString()
        {
            string sent = "ala ma kota";

            string[] res = sent.Split(' ');
            StringBuilder sb = new StringBuilder();
            for (int i = res.Length - 1; i >= 0; i--)
            {
                sb.Append(res[i]);
                sb.Append(" ");
            }
            string result = sb.ToString();
            return result;
        }

        //Using Padding and Subtring for a given string
        public void StringPaddingAndSubstring()
        {
            string transName = "C";
            string companyCode = "0";
            string systemCode = "SM";
            string constract = "0000000610001";
            string companyName = "MyNewCompanyName";

            //StringBuilder has Append
            //String has PadRight/PadLeft
            StringBuilder sb = new StringBuilder(transName.PadRight(2));
            sb.Append(companyCode.PadRight(3));
            sb.Append(constract.PadRight(20));
            sb.Append(systemCode.PadRight(42));
            sb.Append(companyName);

            sb.ToString();

        }

        public void  FindAnagrams()
        {
            /*
             * I was asked to write a program to find the anagrams in a list and return the list of anagrams.  
                An anagram is a word or phrase formed by rearranging the letters of a different word
                or phrase, typically using all the original letters exactly once.
                For example, the word anagram itself can be rearranged into nag a ram, 
                also the word binary into brainy and the word adobe into abode.
             */

            List<string> words = new() { "adobe", "binary", "abode", "brainy", "apap" };

            List<string> result = new List<string>();

            //Can I group elements of the list<string> by its length;
            var pr = words
                .GroupBy(w => w.Length)
                .ToDictionary(k => k.Key, v => v.ToList())
                .Where(c => c.Value.Count == 2);

            foreach (var item in pr.AsEnumerable())
            {
                //string to compare int he Value
                List<string> ls = item.Value;
                var temp = new List<string>();
                ls.ForEach(w => {
                    var x = w.OrderBy(l => l).ToString();
                    temp.Add(x);
                });
                if (temp[0].SequenceEqual(temp[1])) 
                {
                    result.Add(temp[0]);
                }
            }

        }
    }
}
