namespace ConAppFunctional.BaseModels;
public class Customer(string firstName)
{
	public int Id { get; set; }
	public string? FirstName { get; set; } = firstName;
	public string? LastName { get; set; }
}
