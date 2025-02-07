using static System.Console;

namespace ConAppPlayingWithFundamentals;

public sealed class Singleton
{
	private static Singleton _instance = null;
	private static readonly object padLock = new();

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
				_instance ??= new Singleton();
				WriteLine(_instance == null ? "Creating new instance !!!" : "Using existing instance !!!");
				return _instance;
			}
		}
	}
}
