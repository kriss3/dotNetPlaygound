namespace ConAppEvents;

public delegate void Notify();
public class DoSomething
{
    public event Notify DoSomethingCompleted;

    public void StartDoSomething() 
    {
        OnCompleted();
    }

    protected virtual void OnCompleted() 
    {
        DoSomethingCompleted?.Invoke();
    }
}
