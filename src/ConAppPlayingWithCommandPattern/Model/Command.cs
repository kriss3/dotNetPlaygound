namespace ConAppCommandPattern.Model;

public abstract class Command(Receiver receiver)
{
    protected Receiver _receiver = receiver;

    public abstract void Execute();
}
