namespace ConAppPlayingWithStrings.Models;

public class Company
{
    public int CompanyId { get; set; }
    public required string Name { get; set; }
    public IList<Employee> Employees { get; set; } = [];
}

public class Employee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Department { get; set; }
}
