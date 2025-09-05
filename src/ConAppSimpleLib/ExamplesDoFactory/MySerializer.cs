using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppSimpleLib.ExamplesDoFactory;
public class MySerializer
{
	public int DoSerializae() 
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

		return result;
	}
}

public class Person 
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Email { get; set; }

}

public class MyDate { }