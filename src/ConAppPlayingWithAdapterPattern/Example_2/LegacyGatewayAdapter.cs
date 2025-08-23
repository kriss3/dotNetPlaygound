namespace ConAppPlayingWithAdapterPattern.Example_2;

// Adapter (Object Adapter)
public sealed class LegacyGatewayAdapter : IPaymentProcessor
{
	public bool Charge(string cardNumber, decimal amount)
	{
		throw new NotImplementedException();
	}
}
