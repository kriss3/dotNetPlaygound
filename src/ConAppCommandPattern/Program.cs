using ConAppCommandPattern.Model;
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
            Receiver receiver = new();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new();

            // now that I have infra ready make a setup:

            inv.SetCommand(cmd);
            inv.ExecuteCommand();

            ReadKey();
        });
    }
}
