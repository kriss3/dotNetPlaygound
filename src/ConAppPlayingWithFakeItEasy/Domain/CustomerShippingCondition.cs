namespace ConAppPlayingWithFakeItEasy.Domain;
public class CustomerShippingCondition
{
	public static bool Check(CustomerWithAddress cust) 
	{
		return cust.AddressList.Any() &&
			cust.Age > 21;
	}
}
