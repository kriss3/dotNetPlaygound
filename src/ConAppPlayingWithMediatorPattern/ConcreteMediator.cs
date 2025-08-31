using ConAppMediatorPattern.Structural;
using ConAppPlayingWithMediatorPattern.Structural;

namespace ConAppPlayingWithMediatorPattern; 
public class ConcreteMediator: Mediator
{
	private readonly List<Colleague> colleagues = [];

	public void Register(Colleague colleague)
	{
		colleague.SetMediator(this);
		colleagues.Add(colleague);
	}

	public T CreateColleague<T>() where T : Colleague, new() 
	{
		var c = new T();
		c.SetMediator(this);
		colleagues.Add(c);
		return c;
	} 

	public override void Send(string message, Colleague colleague)
	{
		colleagues
			.Where(c => c != colleague)
			.ToList()
			.ForEach(c => c.HandleNotification(message));
	}
}
