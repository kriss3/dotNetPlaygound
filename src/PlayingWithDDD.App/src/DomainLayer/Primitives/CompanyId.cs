namespace PlayingWithDDD.App.src.DomainLayer.Primitives;


public record CompanyId
{
	public int Value { get; }

	private CompanyId(int value)
	{
		Value = value;
	}

	public static CompanyId Create(int value)
	{
		if (value <= 0)
		{
			throw new ArgumentException("CompanyId cannot be less than or equal to 0", nameof(value));
		}

		return new CompanyId(value);
	}
}
