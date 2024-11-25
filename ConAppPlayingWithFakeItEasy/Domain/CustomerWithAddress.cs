using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithFakeItEasy.Domain;
public class CustomerWithAddress
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? MiddleName { get; set; }
	public string FullName { get { return $"{FirstName} {MiddleName} {LastName}"; } }
	public int Age { get; set; }
	public List<Address> AddressList { get; set; }

	public CustomerWithAddress(
		string? firstName,
		string? lastName,
		string? middleName,
		int age,
		List<Address> addressList)
	{
		FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
		LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
		MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
		Age = age;
		AddressList = addressList ?? throw new ArgumentNullException(nameof(addressList));
	}
}
