using System;

namespace ConAppEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Handling events!!!");

            DoSomething ds = new DoSomething();

            ds.DoSomethingCompleted += Ds_DoSomethingCompleted;
            //some code here and only when we ready we can call it...

            ds.StartDoSomething();
        }

        private static void Ds_DoSomethingCompleted()
        {
            Console.WriteLine("DoSomething Happend!!!");
        }
    }
}
