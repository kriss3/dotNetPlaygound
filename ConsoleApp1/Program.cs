using static System.Console;

namespace ConApp_Exercises_2;

class Program
{
	static void Main()
	{
		// Constructors call Factory Method
		Document[] docs = [new Resume(), new Report()];

		foreach (var doc in docs)
		{
			WriteLine($"\n {doc.GetType().Name} --");
			foreach (Page p in doc.Pages)
			{
				WriteLine($" {p.GetType().Name}");
			}
		}
		ReadLine();
	}
}
