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


        });
    }
}
