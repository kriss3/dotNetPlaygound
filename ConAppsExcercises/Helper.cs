using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppsExcercises
{
    public class Helper
    {
        public bool IsPalindrom(string word)
        {
            var s = word.ToLower();
            char[] test = word.ToLower().ToCharArray();
            Array.Reverse(test);
            var res = new String(test);

            return s.Equals(res) ? true : false;
        }
        
        public IEnumerable<string> GetPresidents()
        {
            var presidents = new LinkedList<string>();
            presidents.AddLast("JFK");
            presidents.AddLast("Lyndon B Johnson");
            presidents.AddLast("Richard Nixon");
            presidents.AddLast("Jimmy Carter");

            var lln = new LinkedListNode<string>("John F. Kennedy");

            presidents.RemoveFirst();
            presidents.AddFirst(lln);
            return presidents;
        }

        public IEnumerable<string> GetNames()
        {
            var st = new Stack<string>();
            return st;
        }

        public IEnumerable<string> GetValue()
        {
            var q = new Queue<string>();
            return q;
        }

        public string ReverseStringWithVowelsOnly(string input)
        {
            var result = new StringBuilder();
            var inputArr = input.ToCharArray();
            var vowels = new char[] {'a','o','u','y','e'};
            //wenkola

            for (int i = 0; i < inputArr.Length; i++)
            {
                if (vowels.Contains(inputArr[i]))
                {
                    for (var k = inputArr.Length - 1; k >= 0; k--)
                    {
                        if (vowels.Contains(inputArr[inputArr.Length - 1]))
                        {
                            var lastVowel = inputArr[inputArr.Length - 1];
                            inputArr[i] = lastVowel;
                            result.Append(inputArr[i]);
                            break;
                        }
                    }
                }
                else
                {
                    result.Append(inputArr[i]);
                }
            }
            return result.ToString();
        }

        public string ReverseVowels(string s)
        {
            var stringbuilder = new StringBuilder();
            for (int start = 0, end = s.Length - 1; start < s.Length; start++)
            {
                if ("aeiouAEIOU".IndexOf(s[start]) < 0)
                {
                    stringbuilder.Append(s[start]);
                }
                else
                {
                    while (end >= 0 && "aeiouAEIOU".IndexOf(s[end]) < 0)
                    {
                        end--;
                    }
                    stringbuilder.Append(s[end]);
                    end--;
                }
            }

            return stringbuilder.ToString();
        }
    }
}
