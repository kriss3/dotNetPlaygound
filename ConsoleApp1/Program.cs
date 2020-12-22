using System;
using System.Collections.Generic;
using static System.Console;

namespace ConApp_Excercises_2
{
    class Program
    {
        static void Main()
        {
            WriteLine("Hello World!");
            Document[] d = new Document[2];
            d[0] = new Resume();
            d[1] = new Report();
            ReadLine();
        }
    }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class Document
    {
        private readonly List<Page> _pages = new List<Page>();

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
        public void WhatAmIm()
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

}
