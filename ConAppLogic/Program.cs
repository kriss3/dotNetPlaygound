
using ConAppLogic.Extensions;
using static System.Console;


namespace ConAppLogic;

public class Program 
{
    public static void Main() 
    {
		WriteLine("Hello, World!");

		Customer customer1 = new()
		{
			Id = 1,
			IsMedical = true,
			BillingAddress = new Address() { StateCode = "MO" },
			MedicalInfo = new MedicalInformation() { MedicalCard = "PAT123456" }
		};

		if (customer1.IsMedical && customer1.ValidatePatientLocation())
			WriteLine("Customer is from the IN-State");
		else
			WriteLine("Out-of-State customer");

	}

}

public readonly struct Option<T>
{
    private readonly T? value;
    public bool HasValue { get; }

    private Option(T? value, bool hasValue)
    {
        this.value = value;
        HasValue = hasValue;
    }

    public T? Value
    {
        get
        {
            if (!HasValue)
                throw new InvalidOperationException("Optional object must have a value.");

            return value;
        }
    }

    public static Option<T> FromNullable(T value)
    {
        if (value == null)
            return new Option<T>(default, false);

        return new Option<T>(value, true);
    }
}





