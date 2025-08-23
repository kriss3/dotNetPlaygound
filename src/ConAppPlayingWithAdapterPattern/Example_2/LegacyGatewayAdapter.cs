namespace ConAppPlayingWithAdapterPattern.Example_2;

// Adapter (Object Adapter)
public sealed class LegacyGatewayAdapter(LegacyGateway legacyGateway) : IPaymentProcessor
{
	private readonly LegacyGateway _legacy = legacyGateway;

	public bool Charge(string cardNumber, decimal amount)
	{
		throw new NotImplementedException();
	}
}
