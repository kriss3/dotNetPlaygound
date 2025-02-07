using static System.Console;

namespace ConAppsExercises;

public interface IServiceBroker
{
    void Serve();
}

public class ServiceProvider : IServiceBroker
{
    public void Serve()
    {
        WriteLine($"Service started ...");
    }
}

public class ServiceConsumer
{
    private IServiceBroker sb;
    public void Start(IServiceBroker s)
    {
        sb = s;
        WriteLine("Service Caller");
        sb.Serve();
    }
      
}

class MethodInjection
{
    public MethodInjection()
    {
        ServiceConsumer sc = new ServiceConsumer();
        sc.Start(new ServiceProvider());
    }
}
