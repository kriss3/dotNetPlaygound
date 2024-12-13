using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithFakeItEasy.Domain;
public class Customer
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string FullName { get { return $"{FirstName} {LastName}"; } }
	public int Age { get; set; }
	public string? Address { get; set; }

	public Customer(string? firstName, string? lastName, int age, string? address)
	{
		FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
		LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
		Age = age;
		Address = address ?? throw new ArgumentNullException(nameof(address));
	}
}
