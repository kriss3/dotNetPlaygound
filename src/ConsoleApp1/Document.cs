using System.Collections.Generic;

namespace ConApp_Exercises_2;

/// <summary>
/// The 'Creator' abstract class
/// </summary>
abstract class Document
{
	private readonly List<Page> _pages = [];

	// Constructor calls abstract Factory method
	public Document()
	{
		this.CreatePages();
	}

	public List<Page> Pages
	{
		get { return _pages; }
	}

	// Factory Method
	public abstract void CreatePages();
}
