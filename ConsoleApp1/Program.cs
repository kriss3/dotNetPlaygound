﻿using System.Collections.Generic;
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

/// <summary>
/// The 'Product' abstract class
/// </summary>
abstract class Page {  }

/// <summary>
/// A 'ConcreteProduct' class
/// </summary>
class SkillsPage : Page
{
	public static void WhatAmIm()
	{
		WriteLine($"I am SkillsPage");
	}
}

internal class Resume : Document
{
	public override void CreatePages()
	{
		Pages.Add(new SkillsPage());
	}
}

internal class Report : Document
{
	public override void CreatePages()
	{
		Pages.Add(new SkillsPage());
	}
}
