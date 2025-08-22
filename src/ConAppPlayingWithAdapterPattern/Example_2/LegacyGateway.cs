namespace ConAppPlayingWithAdapterPattern.Example_2;


// Adaptee (3rd party / legacy)
public sealed class LegacyGateway
{
	public string MakePayment(decimal money, string cc) => money > 0 ? "OK" : "ERR";
}
