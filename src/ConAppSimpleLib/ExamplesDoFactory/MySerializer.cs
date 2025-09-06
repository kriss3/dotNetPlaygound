using Cova.Functional;
using Cova.ServiceErrors.Errors;
using System.Text.Json;
using System.Text.RegularExpressions;


namespace ConAppSimpleLib.ExamplesDoFactory;

/// How would I go about changing return signature to Result<TSuccess, TFailure>?
public class MySerializer
{
	public static Result<int, ServiceError> DoSerialize() 
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

		return Result.Create(myJson is not null, result, UnexpectedError.Create("The serialization was not successful."));
	}

	public static int DoDeserialize(Person person)
	{
		ArgumentNullException.ThrowIfNullOrEmpty(nameof(person));
		var result  = -1;

		var mySerializer = JsonSerializer.Serialize<Person>(person);
		if (mySerializer is not null) 
			result = 1;
		return result;
	}

	public static int DoSerialize(
		string firstName, 
		string lastName,
		string email,
		int year, 
		int month, 
		int day) 
	{
		var result = -1;
		var fName = PersonName.Create(firstName);
		var lName = PersonName.Create(lastName);
		var emailAddress = Email.Create(email);

		var personObj = new Person(fName, lName, emailAddress);
		//var personObj = new Person
		//{
		//	FirstName = firstName,
		//	LastName=lastName,
		//	Email = email,
		//	DateOfBirth = new MyDate { Day = day, Month = month, Year = year }
		//};

		var mySerializer = JsonSerializer.Serialize(personObj);
		if (mySerializer is not null)	
			result = 1;

		return result;
	}
}

public record Person(Result<PersonName, ServiceError> FirstName, 
	Result<PersonName, ServiceError> LastName, Result<Email, ServiceError> EmailAddress);

public class PersonName 
{
	public string? Value { get; }
	PersonName(string value) => Value = value;

	public static Result<PersonName, ServiceError> Create(string name) 
	{
		return Result.Create(
			!string.IsNullOrEmpty(name),
			() => new PersonName(name),
			() => ValidationError.Create("Name must be provided."));
	}
}

public class Email
{
	public string? Value { get; }

	Email(string value) => Value = value;

	private static readonly Regex EmailRegex =
		new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
			RegexOptions.Compiled | 
			RegexOptions.CultureInvariant | 
			RegexOptions.IgnoreCase);


	public static Result<Email, ServiceError> Create(string email)
	{
		var emailCandidate = (email ?? string.Empty).Trim();
		// additional validation needed for email (regex)
		return Result.Create(EmailRegex.IsMatch(emailCandidate),
			() => new Email(emailCandidate),
			() => ValidationError.Create("Invalid email address."));
	}
}

public class MyDate 
{
	public int Year { get; set; }
	public int Month { get; set; }
	public int Day { get; set; }
}
