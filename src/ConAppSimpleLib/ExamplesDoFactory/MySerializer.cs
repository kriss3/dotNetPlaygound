using Microsoft.VisualBasic;
using System.Text.Json;


namespace ConAppSimpleLib.ExamplesDoFactory;
public class MySerializer
{
	public static int DoSerialize() 
	{
		var result = -1;

		var obj = new Person
		{
			FirstName = "Sander",
			LastName = "Chaney",
			Email = "schaney@gmail.com",
			DateOfBirth = new MyDate
			{
				Year = 1988,
				Month = 4,
				Day = 30
			}
		};

		var myJson = JsonSerializer.Serialize(obj);
		if (myJson is not null)
			result = 1;

		return result;
	}

	public static int DoDeserialize(Person person)
	{
		ArgumentNullException.ThrowIfNullOrEmpty(nameof(person));
		var result  = -1;

		var mySerializer = JsonSerializer.Serialize<Person>(person);
		return result;
	}

	public static int DoSerialize(string firstName, string lastName, string email, int year, int, month, int day) 
	{
		var result = -1;
		var personObj = new Person 
		{
			FirstName = firstName,
		}

		return result;
	}
}

public class Person 
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }

	public MyDate? DateOfBirth { get; set; }

}

public class MyDate 
{
	public int Year { get; set; }
	public int Month { get; set; }
	public int Day { get; set; }
}
