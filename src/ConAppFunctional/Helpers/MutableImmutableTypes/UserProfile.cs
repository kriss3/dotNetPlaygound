namespace ConAppFunctional.Helpers.MutableImmutableTypes;

public class UserProfile
{
	private User? _user;
	private readonly string? _address;
	public void UpdateUser(int userId, string name)
	{
		_user = new User(userId, name);
	}
}

