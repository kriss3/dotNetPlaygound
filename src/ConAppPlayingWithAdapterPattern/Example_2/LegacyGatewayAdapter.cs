namespace ConAppPlayingWithAdapterPattern.Example_2;

// Adapter (Object Adapter)
public sealed class LegacyGatewayAdapter(LegacyGateway legacyGateway) : IPaymentProcessor
{
	private readonly LegacyGateway _legacy = legacyGateway;

	public bool Charge(string cardNumber, decimal amount)
	{
		var status = _legacy.MakePayment(amount, cardNumber);
		return string.Equals(status, "OK", StringComparison.Ordinal);
	}
}
