namespace ConAppPbP;

public class SingletonExample
{
	private static SingletonExample? mySingleton;
	protected SingletonExample() { }

	private static readonly object syncLock = new();

	public static SingletonExample Instance()
	{
		if (mySingleton == null)
		{
			lock (syncLock)
			{
				mySingleton ??= new SingletonExample();
			}
		}
		return mySingleton;
	}
}