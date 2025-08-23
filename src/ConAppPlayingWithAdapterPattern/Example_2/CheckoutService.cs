namespace ConAppPlayingWithAdapterPattern.Example_2;

// Client
public sealed class CheckoutService(IPaymentProcessor payments)
{
	private readonly IPaymentProcessor _payments = payments;

	public bool PayOrder(string card, decimal total) => _payments.Charge(card, total);
}
