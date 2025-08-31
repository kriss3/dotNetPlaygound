namespace Models;
public class KwsResult_v2
{
	public bool IsSuccess { get; }
	public ErrorType? ErrorType { get; private set; }
	public bool IsFailure => !IsSuccess;

	protected KwsResult_v2(bool isSuccess, ErrorType? errorType)
	{
		if (isSuccess && errorType != null)
			throw new InvalidOperationException();
		if (!isSuccess && errorType == null)
			throw new InvalidOperationException();

		IsSuccess = isSuccess;
		ErrorType = errorType;
	}

	public static KwsResult_v2 Fail(ErrorType errorType)
	{
		return new KwsResult_v2(false, errorType);
	}

	public static KwsResult_v2<T> Fail<T>(ErrorType errorType)
	{
		return new KwsResult_v2<T>(default!, false, errorType);
	}

	public static KwsResult_v2 Ok()
	{
		return new KwsResult_v2(true, null);
	}

	public static KwsResult_v2<T> Ok<T>(T value)
	{
		return new KwsResult_v2<T>(value, true, null);
	}
}

public class KwsResult_v2<T> : KwsResult_v2
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

	protected internal KwsResult_v2(T value, bool isSuccess, ErrorType? errorType) 
		: base(isSuccess, errorType)
	{
		_value = value;
	}
}
