namespace ConAppPlayingWithFakeItEasy.Domain;
public class CustomerShippingCondition
{
	public static bool Check(CustomerWithAddress cust) 
	{
		return cust.AddressList.Count != 0 &&
			cust.Age > 21;
	}
}
