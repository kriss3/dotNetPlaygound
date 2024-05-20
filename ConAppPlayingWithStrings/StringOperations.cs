using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace ConAppPlayingWithStrings;

public static class StringOperations
{
    public static string VowelsString()
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

    public static void StrStats() //a dictionary of char key and number of reoccuring characters;
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
    public static bool IsReversedStringTheSame()
    {
        var str = "abba";
        if (!string.IsNullOrEmpty(str))
        {
            return str.SequenceEqual(str.Reverse());
        }
        return false;
    }

    //Reverse words in the string
    public static string ReverseWordsInString()
    {
        string sent = "ala ma kota";

        string[] res = sent.Split(' ');
        StringBuilder sb = new();
        for (int i = res.Length - 1; i >= 0; i--)
        {
            sb.Append(res[i]);
            sb.Append(' ');
        }
        string result = sb.ToString();
        return result;
    }

    //Using Padding and Substring for a given string
    public static string StringPaddingAndSubstring()
    {
        string transName = "C";
        string companyCode = "0";
        string systemCode = "SM";
        string construct = "0000000610001";
        string companyName = "MyNewCompanyName";

        //StringBuilder has Append
        //String has PadRight/PadLeft
        StringBuilder sb = new(transName.PadRight(2));
        sb.Append(companyCode.PadRight(3));
        sb.Append(construct.PadRight(20));
        sb.Append(systemCode.PadRight(42));
        sb.Append(companyName);

       return sb.ToString();
    }

    public static void  FindAnagrams()
    {
        /*
         * I was asked to write a program to find the anagrams in a list and return the list of anagrams.  
            An anagram is a word or phrase formed by rearranging the letters of a different word
            or phrase, typically using all the original letters exactly once.
            For example, the word anagram itself can be rearranged into nag a ram, 
            also the word binary into brainy and the word adobe into abode.
         */

        List<string> words = ["adobe", "binary", "abode", "brainy", "apap"];

        List<string> result = [];

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
        //to be continued... add test cases...
    }

    public static string SortAndRemoveStringWord() 
    {
        string example = "aacbkimp"; //abcikmp
        string result = string.Concat(example.OrderBy(c => c).Distinct());
        return result;      
    }

    //Prints a star patters on the screen;
    public static void PrintStarPattern(int n)
    {
        for (int i = n; i > 0; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Write($"*");
            }
            WriteLine();
        }
    }

    public static void StringsOperations(string val)
    {
        var t = val.Length;
        for (int i = 0; i < val.Length; i++)
        {
            Debug.WriteLine(val[i]);
        }
        Debug.WriteLine("");
        for (var m = val.Length - 1; m >= 0; m--)
        {
            Debug.WriteLine(val[m]);
        }
        Debug.WriteLine("");
        for (var m = (val.Length - 1) / 2; m >= 0; m--)
        {
            Debug.WriteLine(val[m]);
        }
        Debug.WriteLine("");
        Debug.WriteLine(val.Length);
        Debug.WriteLine(val.Length);
        var k = val.OrderBy(x => x.ToString());
    }

    public static string ObfString(string val) 
    {
        string result = string.Empty;

        var sth = val[..^4];
        //var astrx = sth.Replace()

        //var regEx = new Regex(".{4}(?=\\s|$)");
        //var x = Regex.Replace("1002945", @"#(.4)", "*");
        result = val.Substring(val.Length - 4).PadLeft(val.Length, '*');

        var res2 = val.toMask(4);

        return result; 
    }

}
