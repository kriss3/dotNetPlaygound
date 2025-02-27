

using ConAppPlayingWithProxyPattern.Interfaces;
using static System.Console;


namespace ConAppPlayingWithProxyPattern.AccessControl;

public class DataServiceProxy : IDataAccess
{
	private readonly RealDataService _realDataService = new();

	public void FetchData(string userRole)
	{
		if (!userRole.Equals("Admin")) 
		{
			WriteLine("Access Deny!/nYou are not authorized to access this data.");
			return;
		}
		_realDataService.FetchData(userRole);
	}
}
