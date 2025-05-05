namespace ConAppFunctional.Helpers.MutableImmutableTypes;

public class UserProfile
{
	private FunctionalUser? _user;
	private readonly string? _address;
	public void UpdateUser(int userId, string name)
	{
		_user = new FunctionalUser(userId, name);
	}
}

