namespace ConAppPlayingWithAdapterPattern.Example_2;

// Client
public sealed class CheckoutService
{
	private readonly IPaymentProcessor _payments;
	public CheckoutService(IPaymentProcessor payments) => _payments = payments;
	public bool PayOrder(string card, decimal total) => _payments.Charge(card, total);
}
