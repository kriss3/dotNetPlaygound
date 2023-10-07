using System.Collections.Generic;

namespace ConAppPlayingWithStrings.Models;

public class Company
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public IList<Employee> Employees { get; set; } = new List<Employee>();
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
}
