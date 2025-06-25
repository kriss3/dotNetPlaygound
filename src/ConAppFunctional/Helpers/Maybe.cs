using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppFunctional.Helpers;
public class Maybe<T> : IEquatable<Maybe<T>>
	where T : class
{
	private readonly T _value;
	public T Value 
	{
		get 
		{
			if (HasNoValue)
				throw new InvalidOperationException();

			return _value;
		}
	}

	public bool HasValue => _value != null;
	public bool HasNoValue => !HasValue;


	public bool Equals(Maybe<T>? other)
	{
		throw new NotImplementedException();
	}
}
