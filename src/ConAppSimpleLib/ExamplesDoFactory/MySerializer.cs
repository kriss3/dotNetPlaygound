using Cova.Functional;
using Cova.ServiceErrors.Errors;
using Microsoft.VisualBasic;
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
		var dobYear = Year.Create(year);
		var dobMonth = Month.Create(month);	
		var dobDay = Day.Create(day);

		var personObj = new Person(fName, lName, emailAddress, );
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
	Result<PersonName, ServiceError> LastName, Result<Email, ServiceError> EmailAddress, MyDate MyDate);

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
	public Year Year { get; }
	public Month Month { get; }
	public Day Day { get; }
	public MyDate? Value { get; }

	private MyDate(Year year, Month month, Day day) 
	{

	}

	public static Result<MyDate, ServiceError> Create(MyDate value) => Valu
}

public class Year(int value)
{
	public int Value { get; } = value;

	public static Result<Year, ServiceError> Create(int year) 
	{
		return Result.Create(
			year > 1900,
			() => new Year(year),
			() => ValidationError.Create("Invalid Year value for Date of Birth."));
	}
}

public class Month(int value)
{
	public int Value { get; } = value;

	public static Result<Month, ServiceError> Create(int month)
	{
		return Result.Create(
			(month > 1 && month <= 12),
			() => new Month(month),
			() => ValidationError.Create("Invalid Month value for Date of Birth."));
	}
}

public class Day(int value)
{
	public int Value { get; } = value;

	public static Result<Day, ServiceError> Create(int day)
	{
		return Result.Create(
			(day > 0 && day < 31),
			() => new Day(day),
			() => ValidationError.Create("Invalid Day value for Date of Birth."));
	}
}
