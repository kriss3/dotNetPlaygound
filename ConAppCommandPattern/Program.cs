using Microsoft.VisualBasic;
using static System.Console;

namespace ConAppCommandPattern;

public class Program
{
    static async Task Main(string[] args)
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
            Receiver rc = new Receiver();
            Command cmd = new Command(rc);
            Inoker inv = new Inoker();  

            // now that I have infra ready make a setup:

            inv.SetCommand(cmd);
            inv.ExecuteCommand();

            ReadKey();
        });
    }
}

public class Receiver
{
    public void Action()
    {
        WriteLine("Receiver.Action() called");
    }
}

public abstract class Command(Receiver receiver)
{
    protected Receiver _receiver = receiver;

    public abstract void Execute();
}
