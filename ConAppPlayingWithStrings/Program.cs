﻿using ConAppPlayingWithStrings.Models;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConAppPlayingWithStrings
{
    internal class Program
    {
        private static StringOperations Sop { get; set; }
        static void Main(string[] args)
        {
            WriteLine("Hello World!");
            Sop = new StringOperations();
            //VowelsStringOperation();
            //CompareStrings();
            //FindAnagrams();
            //SortAndRemoveDuplicatesFromString();
            //PrintStarPattern();
            //WorkingWithStrings();
            //WorkingWithRegEx();
            //var res = FilterAndCreateEmployees();
            var r = MotoRace().ToList();
        }

        private static IEnumerable<int> MotoRace()
        {
            var res = "10,0,4,1,0,10,3,4,6";
            List<int> x = new(res.Split(',')
                .Select(x => int.Parse(x)).OrderBy(x => x));

            x.RemoveRange(0, 3);

            return x;

        }

        private static Company FilterAndCreateEmployees()
        {
            var getData = GetCompanyAndEmployeeData();

            var res = new Company() 
            {
                CompanyId = getData.CompanyId,
                Name = getData.Name,
                Employees = BuildEmployees(getData.Employees)
            };
            return res;
        }

        private static IList<Employee> BuildEmployees(IList<Employee> employees) =>
            employees
            .Where(e => !(string.IsNullOrWhiteSpace(e.Name) || string.IsNullOrWhiteSpace(e.Department)))
            .Select(x => new Employee() { Id = x.Id, Name = x.Name, Department = x.Department })
            .ToList();
  
        //{
        //    var retData = employees.Where(
        //            e => !(string.IsNullOrWhiteSpace(e.Name) || string.IsNullOrWhiteSpace(e.Department))
        //        .Select(d => new Employee() { Id = d.Id, Name = d.Name, Department = d.Department }))
        //        .ToList();
        //    return retData;
        //}

        private static Company GetCompanyAndEmployeeData()
        {
            var dellEmployees = new List<Employee>() 
            {
                new Employee() { Id = 0, Name =  "John Doe", Department = "Software" },
                new Employee() { Id = 1, Name = "Angela Su", Department = "Sales" },
                new Employee() { Id = 2, Name = "Frank Kelvin", Department = "Marketing" },
                new Employee() { Id = 3, Name = "Joe Dustin", Department = "Sales" },
                new Employee() { Id = 4, Name = "Glory GG", Department = "Software" },
                new Employee() { Id = 5, Name = "Antonella Clement", Department = "Marketing" },
                new Employee() { Id = 6, Name = "Andrew Logan", Department = "Software" },
                new Employee() { Id = 7, Name = "Billy Cruz", Department = "Marketing" },
                new Employee() { Id = 8, Name = "Sally Jane", Department = "Software" },
                new Employee() { Id = 9, Name = "John Kane", Department = "Sales" },
                new Employee() { Id = 10, Name = "Jon Bullock", Department = null },
                new Employee() { Id = 11, Name = null, Department = "" }
            };

            var company = new Company() { CompanyId = 0, Name = "Dell", Employees = dellEmployees };
            return company;
        }

        private static void WorkingWithRegEx()
        {
            string val = "abcdefg1234";
            Sop.ObfString(val);
        }

        private static void WorkingWithStrings()
        {
            string myParam = "spppssp";
            Sop.StringsOperations(myParam);
        }

        private static void VowelsStringOperation() 
        {
            WriteLine(Sop.VowelsString());
        }

        private static void CompareStrings() 
        {
            WriteLine($"The string provided and reversed is the same: {Sop.IsReversedStringTheSame()}");
        }

        private static void ReverseWordsInString()
        {
            WriteLine($"The reversed string is: {Sop.ReverseWordsInString()}");
        }

        private static void ShowStringPaddingAndSubstring()
        {
            Sop.StringPaddingAndSubstring();
        }

        private static void FindAnagrams() 
        {
            Sop.FindAnagrams();
        }

        private static void SortAndRemoveDuplicatesFromString() 
        {
            //string example = "aacbkimp"
            WriteLine($"The result of the string operation: {Sop.SortAndRemoveStringWord()}");
        }

        private static void PrintStarPattern() 
        {
            Sop.PrintStarPattern(8);
        }
    }
}
