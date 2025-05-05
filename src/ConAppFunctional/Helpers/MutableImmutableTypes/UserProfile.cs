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

public class UserProfile_v2(FunctionalUser user, string address) //creation of an instance
{
	private readonly FunctionalUser _user = user;
	private readonly string _address = address;

	public UserProfile_v2 UpdateUser(int userId, string name)// Update User via factory method.
	{
		var newUser = new FunctionalUser(userId, name);
		return new UserProfile_v2(newUser, _address);
	}
}

