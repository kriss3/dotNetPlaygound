using static System.Console;

namespace ConAppsExercises;

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
                    WriteLine($"Using excising instance !!!");
                }
                
                return _instance;
            }
        }
    }
}
