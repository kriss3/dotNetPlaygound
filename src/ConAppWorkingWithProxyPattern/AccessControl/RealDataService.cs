

using ConAppPlayingWithProxyPattern.Interfaces;
using static System.Console;


namespace ConAppPlayingWithProxyPattern.AccessControl;

public class RealDataService : IDataAccess
{
	public void FetchData(string userRole)
	{
		WriteLine("Fetching some very sensitive data from the database...");
	}
}
