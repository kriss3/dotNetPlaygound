using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConAppsExcercises
{
    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object padLock = new object();

        private Singleton()
        {
            WriteLine($"Creating new instance !!!");
        }

        public static Singleton Instance
        {
            get
            {
                lock (padLock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    else
                    {
                        WriteLine($"Using exising instance !!!");
                    }
                    
                    return _instance;
                }
            }
        }
    }
}
