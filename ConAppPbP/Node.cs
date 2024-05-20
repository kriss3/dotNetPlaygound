namespace ConAppPbP
{
	public class Node
    {
        public int Data { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }

        public string DisplayNode() 
        {
            return $"Data in the current Node: {Data}";
        }

    }
}
