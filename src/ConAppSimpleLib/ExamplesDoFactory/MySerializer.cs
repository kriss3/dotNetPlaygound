using Cova.Functional;
using Cova.ServiceErrors.Errors;
using System.Text.Json;
using System.Text.RegularExpressions;


namespace ConAppSimpleLib.ExamplesDoFactory;

//Lesson learnt: You generally don’t want to serialize the Result wrappers.
//Unwrap them (short-circuiting on failure) and serialize a flat DTO.
// This is where I stop this exercise.
public class MySerializer
{
	public static Result<int, ServiceError> DoSerialize() 
	{
		var result = -1;
		var firstName = PersonName.Create("Sander");
		var lastName = PersonName.Create("Chaney");
		var emailAddress = Email.Create("schaney@gmail.com");
		var myDob = MyDate.Create(1988, 4, 30);

		var obj = new Person(firstName, lastName, emailAddress, myDob);

		var myJson = JsonSerializer.Serialize(obj);
		
		return Result.Create(myJson is not null, result, UnexpectedError.Create("The serialization was not successful."));
	}

	public static Result<int, ServiceError> DoSerialize(Person person)
	{
		if (person is null)
			return Result.Create(false, 0, ValidationError.Create("Person object must be provided."));

		try
		{
			var json = JsonSerializer.Serialize(person);
			var ok = !string.IsNullOrEmpty(json);

			//What is Success What is Failure:
			//success => 1, failure => 0
			return Result.Create(
				ok, 
				ok ? 1 : 0, 
				UnexpectedError.Create("The serialization was not successful."));


			
		}
		catch (Exception)
		{

			throw;
		}

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

		var myDob = MyDate.Create(year, month, day);



		var personObj = new Person(
			fName, 
			lName, 
			emailAddress,
			myDob);

		var mySerializer = JsonSerializer.Serialize(personObj);
		if (mySerializer is not null)	
			result = 1;

		return result;
	}
}

public record Person(
	Result<PersonName, ServiceError> FirstName, 
	Result<PersonName, ServiceError> LastName, 
	Result<Email, ServiceError> EmailAddress, 
	Result<MyDate, ServiceError> Dob);


#region Primitives

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

public class MyDate(int dobYear, int dobMonth, int dobDay)
{
	public int DobYear { get; } = dobYear;
	public int DobMonth { get; } = dobMonth;
	public int DobDay { get; } = dobDay;

	public static Result<MyDate, ServiceError> Create(int year, int month, int day)
	{
		bool valid = ((year > 1920 && year < 2100) && (month > 1 && month <= 12) && (day > 1 && day <= 31));

		return Result.Create<MyDate, ServiceError>(
			valid,
			() => new MyDate(year, month, day),
			() => UnexpectedError.Create(""));
	}
}

#endregion
