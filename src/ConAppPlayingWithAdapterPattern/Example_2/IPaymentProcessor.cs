namespace ConAppPlayingWithAdapterPattern.Example_2;
public interface IPaymentProcessor
{
	bool Charge(string cardNumber, decimal amount);
}
