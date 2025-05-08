namespace ConAppFunctional.BaseModels;
public class Customer(string firstName, Address address)
{
	public int Id { get; set; }
	public string? FirstName { get; set; } = firstName;
	public string? LastName { get; set; }
	public Address? Address { get; set; } = address;
}
