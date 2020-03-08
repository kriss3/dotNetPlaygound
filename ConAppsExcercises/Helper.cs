using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConAppsExcercises
{
    public class Helper
    {
        public bool IsPalindrom(string word)
        {
            var s = word.ToLower();
            char[] test = word.ToLower().ToCharArray();
            Array.Reverse(test);
            var res = new string(test);

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
            var vowels = new char[] {'a','o','u','y','e','i'};
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
                if ("aeiouAEIOU".IndexOf(s[start]) < 0) // if s[start] retuns -1 meaning not there ...
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

        public IList<int> ArrrayGames()
        {
            int[] result = {1,4,9,16,25};

            return result;
        }

        public IList<string> GetWeekName()
        {
            string[] results = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < results.Length; i++)
            {
                sb.Append(results[i]);
                if (i < results.Length - 2)
                {
                    sb.Append(", ");
                }
                if (i == results.Length - 2)
                {
                    sb.Append(" and ");
                }
            }
            WriteLine(sb.ToString());
            return results;
        }

        public IList<Person> GetPeople()
        {
            Person[] people = new Person[]
            {
                new Person { Name="Kris", Age=11},
                new Person { Name= "Tom", Age=20}
            };

            foreach (var item in people)
            {
                WriteLine(item.ToString());
            }
            return people;
        }

        public void CopyArray()
        {
            int[] myBase = { 1, 4, 9, 16, 2, 5};
            int[] copy = new int[6];

            myBase.CopyTo(copy, 0);

            foreach (var item in copy)
            {
                WriteLine(item);
            }

            WriteLine($"myBase Equals to Copy? {myBase == copy}");
        }

        public void UseSingleton()
        {
            Singleton s1 = Singleton.Instance;
            var s2 = Singleton.Instance;
        }

        public string GetCollapsed(string input)
        {
            //group same letters;
            //var gr = input.ToCharArray();
            var dictionary = new Dictionary<char, int>();

            foreach (var l in input)
            {
                if (!dictionary.ContainsKey(l))
                {
                    dictionary[l] = 0;
                }
                dictionary[l]++;
            }

            var results = string.Empty;
            foreach (var rec in dictionary)
            {
                results += rec.Key + rec.Value.ToString();
            }


            return results;
        }

        public DateTime WorldClock(string myDate, IList<string> timeZones)
        {
            //check input parameters => is myDate actually a date?
            //you have 135 time zones => do you want to convert time for eacho of them?
            var dt = Convert.ToDateTime(myDate);

            var destTimeZone = "Central European Standard Time";
            var result = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Local, TimeZoneInfo.FindSystemTimeZoneById(destTimeZone));

            return result;
        }

        public IList<string> GetTimeZoneId()
        {
            var results = new List<String>();
            foreach (var tz in TimeZoneInfo.GetSystemTimeZones())
            {
                results.Add(tz.Id);
            }
            return results;
        }

        public IEnumerable<String> StringsArrays()
        {
            IList<String> myStrings = new List<string>();
            string[] myArr = { "a","e","i","o","u","y"};
            var t = "aeiouy";
            var res = t.ToCharArray();
            for (int i = res.Length-1; i>0;i++)
            {
                WriteLine(t[i]);
            }

            return myStrings;
        }

        public void SwapMinMax()
        {
            int[] arr = { 1, 4, 5, 3, 2, 7, 6, 8, 9, 11 };
            Array.Sort(arr);
            var min = arr[0];
            var max = arr[arr.Length -1];

            arr[0] = max;
            arr[arr.Length - 1] = min;
        }

        public void SwapString()
        {
            var word = "test"; //test => tset
            var t = word.ToCharArray();
            var len = t.Length -1;
            var mid = len / 2;

            for (var i = 0; i <= mid; i++)
            {
                var myChar = t[i];
                t[i] = t[len - i];
                t[len - i] = myChar;
            }

            t.ToString();
        }

        public string GetConnectinString()
        {
            return ConfigurationManager.ConnectionStrings["BCIT"].ConnectionString;
        }

        public IEnumerable<string> GetAllItems()
        {
            var result = new List<string>();
            using (SqlConnection conn = new SqlConnection(GetConnectinString()))
            {
                SqlCommand cmd = new SqlCommand("dbo.getItems", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        result.Add(dr.GetString(0));
                    }
                }
            }
            return result;
        }

        public string GetItemById(int val)
        {
            var result = String.Empty;
            using (SqlConnection conn = new SqlConnection(GetConnectinString()))
            {
                SqlCommand cmd = new SqlCommand("dbo.getItemById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add("@itemId", SqlDbType.Int).Value = val;
                //cmd.Parameters.AddWithValue("@itemId", val);
                
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        result = dr.GetString(1);
                    }
                }
            }
            return result;
        }

        public async Task<string> GetPeopleFromWeb()
        {
            var baseUrl = $"http://peoplecollectionapi.azurewebsites.net/";
            HttpClient _ = new HttpClient();
            var task =  await _.GetStringAsync(new Uri($"{baseUrl}api/people"));
            return task;
        }

    }
}
