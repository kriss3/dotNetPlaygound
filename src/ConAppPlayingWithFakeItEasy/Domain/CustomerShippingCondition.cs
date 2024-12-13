namespace ConAppPlayingWithFakeItEasy.Domain;
public class CustomerShippingCondition
{

	public bool Check(CustomerWithAddress cust) 
	{
		return cust.AddressList.Any() &&
			cust.Age > 21;
	}
}
