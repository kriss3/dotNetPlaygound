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
