namespace ConAppPlayingWithAdapterPattern.Example_2;


// Adaptee (3rd party / legacy)
public sealed class LegacyGateway
{
	public string MakePayment(decimal money, string cc) => money > 0 ? "OK" : "ERR";
}

// Client
public sealed class CheckoutService
{ }

// Adapter (Object Adapter)
public sealed class LegacyGatewayAdapter : IPaymentProcessor
{
	public bool Charge(string cardNumber, decimal amount)
	{
		throw new NotImplementedException();
	}
}
