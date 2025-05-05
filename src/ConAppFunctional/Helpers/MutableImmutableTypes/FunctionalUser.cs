namespace ConAppFunctional.Helpers.MutableImmutableTypes;

public class FunctionalUser(int id, string name)
{
	public int Id { get; } = id;
	public string Name { get; } = name;
}
