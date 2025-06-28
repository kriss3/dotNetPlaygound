namespace ConAppFunctional.Helpers;

public class Maybe<T> : IEquatable<Maybe<T>>
				where T : class
{
	private readonly T? _value;
	public T Value
	{
		get
		{
			if (HasNoValue)
				throw new InvalidOperationException();

			return _value!;
		}
	}

	public bool HasValue => _value != null;
	public bool HasNoValue => !HasValue;

	public bool Equals(Maybe<T>? other)
	{
		if (other is null)
			return false;

		if (ReferenceEquals(this, other))
			return true;

		return EqualityComparer<T>.Default.Equals(_value, other._value);
	}

	public override bool Equals(object? obj)
	{
		if (obj is Maybe<T> other)
			return Equals(other);

		return false;
	}

	public override int GetHashCode()
	{
		return _value?.GetHashCode() ?? 0;
	}
}
