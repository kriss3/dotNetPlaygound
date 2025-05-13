namespace Models;
public class KwsResult
{
	public bool IsSuccess { get; }
	public string? Error { get; private set; }
	public bool IsFailure => !IsSuccess;

	protected KwsResult(bool isSuccess, string error) 
	{
		if (isSuccess && error != string.Empty)
			throw new InvalidOperationException();
		if (!isSuccess && error == string.Empty)
			throw new InvalidOperationException();

		IsSuccess = isSuccess;
		Error = error;
	}

	public static KwsResult Fail(string message) 
	{
		return new KwsResult(false, message);
	}

	public static KwsResult<T> Fail<T>(string message) 
	{
		return new KwsResult<T>(default, false, message);
	}

	public static KwsResult Ok() 
	{
		return new KwsResult(true, string.Empty);
	}

	public static KwsResult<T> Ok<T>(T value) 
	{
		return new KwsResult<T>(value, true, string.Empty);
	}
}

public class KwsResult<T> : KwsResult 
{
	public T? Value { get; }

	internal KwsResult(T? value, bool isSuccess, string error) : base(isSuccess, error) 
	{
		Value = value;
	}
}

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
		return new KwsResult_v2<T>(default, false, errorType);
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
	public T? Value { get; }

	internal KwsResult_v2(T? value, bool isSuccess, ErrorType? errorType) : base(isSuccess, errorType)
	{
		Value = value;
	}
}

// Next: add version of KwsResult with Enums instead of string Error.

public enum ErrorType 
{
	DatabaseIsOffline,
	CustomerAlreadyExists
}