namespace ConAppFunctional.Helpers.MutableImmutableTypes;

public class FunctionalUser(int id, string name)
{
	public int Id { get; } = id;
	public string Name { get; } = name;
}

public class FunctionalUser_v2
{
	public int Id { get; }
	public string Name { get; }
	public FunctionalUser_v2(int id, string name)
	{
		Id = id;
		Name = name;
	}
}


