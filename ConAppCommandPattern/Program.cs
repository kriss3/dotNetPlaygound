using static System.Console;

namespace ConAppCommandPattern;

public class Program
{
    static async Task Main()
    {
        WriteLine("Hello, World!");
        await Run();
    }

    private static async Task Run() 
    {
        await Task.Run(() =>
        {
            //this is my driver function. 
            //I need: Receiver, Command, Invoker
            Receiver rc = new();
            Command cmd = new ConcreteCommand(rc);
            Invoker inv = new();

            // now that I have infra ready make a setup:

            inv.SetCommand(cmd);
            inv.ExecuteCommand();

            ReadKey();
        });
    }
}

public class Receiver
{
    public static void Action()
    {
        WriteLine("Receiver.Action() called");
    }
}

public abstract class Command(Receiver receiver)
{
    protected Receiver _receiver = receiver;

    public abstract void Execute();
}

public class  ConcreteCommand(Receiver receiver) : Command(receiver ?? new Receiver()) 
{
    public override void Execute()
    {
        Receiver.Action();
    }
}

public class Invoker 
{
    Command? _cmd;

    public void SetCommand(Command cmd) 
    {
        _cmd = cmd;
    }
    public void ExecuteCommand()
    {
        _cmd?.Execute();
    }
}
