using System;
using static System.Console;

namespace ConAppEvents;

class Program
{
    static void Main()
    {
        WriteLine("Handling events!!!");

        DoSomething ds = new DoSomething();

        ds.DoSomethingCompleted += Ds_DoSomethingCompleted;
        //some code here and only when we ready we can call it...

        ds.StartDoSomething();
    }

    private static void Ds_DoSomethingCompleted()
    {
        WriteLine("DoSomething Happened!!!");
    }
}
