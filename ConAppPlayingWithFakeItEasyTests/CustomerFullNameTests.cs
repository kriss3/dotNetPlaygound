using AutoFixture;
using AutoFixture.Xunit2;
using ConAppPlayingWithFakeItEasy.Domain;

namespace ConAppPlayingWithFakeItEasyTests;

public class CustomerFullNameTests
{
	[Fact]
	public void FullNameReturnsExpected()
	{
		var sut = new Customer("John", "Doe", 30, "123 Main St");

		var actual = sut.FullName;

		Assert.Equal("John Doe", actual);

	}

	[Theory]
	[InlineData("Mark", "White", "Mark White")]
	[InlineData("VS", "Code", "VS Code")]
	public void FullNameReturnsExpected_v1(
		string firstName,
		string lastName,
		string expected)
	{
		var sut = new Customer(firstName, lastName, 0, "Dummy Address");

		var actual = sut.FullName;

		Assert.Equal(expected, actual);

	}

	[Theory]
	[InlineData("Mark", "White", "Mark White")]
	[InlineData("VS", "Code", "VS Code")]
	public void FullNameReturnsExpected_v2(
		string firstName,
		string lastName,
		string expected)
	{
		var fixture = new Fixture();
		var sut = fixture.Build<Customer>()
			.With(x => x.FirstName, firstName)
			.With(x => x.LastName, lastName)
			.Create();

		var actual = sut.FullName;

		Assert.Equal(expected, actual);

	}

	[Theory]
	[InlineData("Mark", "M", "White", "Mark M White")]
	[InlineData("VS", "S", "Code", "VS S Code")]
	public void FullNameWithMiddleNameReturnsExpected_v1(
	string firstName, string middleName,
	string lastName,
	string expected)
	{
		var fixture = new Fixture();
		var sut = fixture.Build<CustomerWithMIddleName>()
			.With(x => x.FirstName, firstName)
			
			.With(x => x.LastName, lastName)
			.With(x => x.MiddleName, middleName)
			.Create();

		var actual = sut.FullName;

		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineAutoData("Mark", "M", "White", "Mark M White")]
	[InlineAutoData("VS", "S", "Code", "VS S Code")]
	public void FullNameWithMiddleNameReturnsExpected_v2(
		string firstName, 
		string middleName,
		string lastName,
		string expected,
		CustomerWithMIddleName sut)
	{
		sut.FirstName = firstName;
		sut.MiddleName = middleName;
		sut.LastName = lastName;

		var actual = sut.FullName;

		Assert.Equal(expected, actual);
	}

	[Theory]
	[InlineAutoData(22, true)]
	[InlineAutoData(40, true)]
	[InlineAutoData(21, false)]
	[InlineAutoData(11, false)]
	public void ForCustomerWithAddressShippingCondition(
		int age,
		bool expected,
		CustomerWithAddress customer,
		CustomerShippingCondition sut) 
	{
		customer.Age = age;
		var actual = sut.Check(customer);

		Assert.Equal(expected, actual);
	}
}
