using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Console;

namespace ConAppsExcercises
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            //MyEvents();
            Run();
            ReadLine();
        }

        private static void MyEvents()
        {
            NotificationMethods nm = new NotificationMethods();
           
            nm._shaw += Nm__shaw;

            nm.Name = "Kris";

        }

        private static void Nm__shaw(object sender, EventArgs args)
        {
            WriteLine($"Name property has changed...");
        }

        public static void Run()
        {
            Helper h = new Helper();

            var tz = h.GetTimeZoneId();
            h.WorldClock("2017-11-25 3:32pm", tz);
            h.GetCollapsed("yyyaaa");
            h.UseSingleton();
            var a = h.GetWeekName();
            var r = h.ReverseVowels("Whyeeko");
            var k = h.GetPresidents();
            Write(@"Type word to check if Palindrom: ");
            var s = ReadLine();
            if (h.IsPalindrom(s))
            {
                WriteLine($"Word {s} is palindrom");
            }
            else
            {
                WriteLine($"Word {s} is not a palindrom");
            }
        }

        protected virtual void GetDog()
        {
            WriteLine($"This is inside method: {MethodBase.GetCurrentMethod().Name}()");
        }

        protected virtual void GetCat()
        {
            WriteLine($"This is inside method: {MethodBase.GetCurrentMethod().Name}()");
        }
    }
}
