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
		return new KwsResult<T>(default(T), false, message);
	}

	public static KwsResult Ok() 
	{
		return new KwsResult(true, string.Empty);
	}

	public static KwsResult<T> Ok<T>(T value) 
	{
		return new KwsResult<>(value, true, string.Empty);
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