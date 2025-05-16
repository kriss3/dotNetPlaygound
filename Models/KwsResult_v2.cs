namespace Models;
public class KwsResult_v2
{
	public bool IsSuccess { get; }
	public ErrorType? ErrorType { get; private set; }
	public bool IsFailure => !IsSuccess;

	protected KwsResult_v2(bool isSuccess, string error)
	{
		if (isSuccess && error != string.Empty)
			throw new InvalidOperationException();
		if (!isSuccess && error == string.Empty)
			throw new InvalidOperationException();

		IsSuccess = isSuccess;
		Error = error;
	}

	public static KwsResult_v2 Fail(string message)
	{
		return new KwsResult_v2(false, message);
	}

	public static KwsResult_v2<T> Fail<T>(string message)
	{
		return new KwsResult_v2<T>(default!, false, message);
	}

	public static KwsResult_v2 Ok()
	{
		return new KwsResult_v2(true, string.Empty);
	}

	public static KwsResult<T> Ok<T>(T value)
	{
		return new KwsResult<T>(value, true, string.Empty);
	}
}

public class KwsResult_v2<T> : KwsResult
{
	private readonly T _value;

	public T Value
	{
		get
		{
			if (!IsSuccess)
				throw new InvalidOperationException();
			return _value;
		}
	}

	protected internal KwsResult_v2(T value, bool isSuccess, string error) : base(isSuccess, error)
	{
		_value = value;
	}
}
