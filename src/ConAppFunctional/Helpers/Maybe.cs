using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppFunctional.Helpers;
public class Maybe<T> : IEquatable<Maybe<T>>
	where T : class
{
	public bool Equals(Maybe<T>? other)
	{
		throw new NotImplementedException();
	}
}
