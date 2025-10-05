using System.Collections.Generic;

namespace ConAppPlayingWithFactoryMethod;

/// <summary>
/// The 'Creator' abstract class
/// </summary>
abstract class Document
{
	private readonly List<Page> _pages = [];

	// Constructor calls abstract Factory method
	public Document()
	{
		CreatePages();
	}

	public List<Page> Pages
	{
		get { return _pages; }
	}

	// Factory Method
	public abstract void CreatePages();
}
