namespace ConAppFunctional.Helpers;

public class UserProfile
{
	private User? _user;
	private string? _address;
	public void UpdateUser(int userId, string name)
	{
		_user = new User(userId, name);
	}
}

