using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConAppPbP
{
    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public void DisplayNode() 
        {
            WriteLine($"Data in the current Node: {Data}");
        }

    }
}
