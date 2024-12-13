namespace ConAppCommandPattern.Model;

public class ConcreteCommand(Receiver receiver) : Command(receiver ?? new Receiver())
{
    public override void Execute()
    {
        Receiver.Action();
    }
}
