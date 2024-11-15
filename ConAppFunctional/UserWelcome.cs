using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cova.Functional;
using Cova.ServiceErrors.Errors;

namespace ConAppFunctional;
public class UserWelcome
{



}

public record User
{
	public string? Name { get; init; }
	public int Age { get; init; }
}
