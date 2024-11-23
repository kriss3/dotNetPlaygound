using ConAppPlayingWithFakeItEasy.Domain;
using FluentAssertions;

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
}
