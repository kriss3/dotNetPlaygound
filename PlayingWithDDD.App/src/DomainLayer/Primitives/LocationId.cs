namespace PlayingWithDDD.App.src.DomainLayer.Primitives;

public record LocationId 
{
	public int Value { get; }

	private LocationId(int value)
	{
		Value = value;
	}

	public static LocationId Create(int value)
	{
		if (value <= 0)
		{
			throw new ArgumentException("LocationId cannot be less than or equal to 0", nameof(value));
		}
		return new LocationId(value);
	}
}