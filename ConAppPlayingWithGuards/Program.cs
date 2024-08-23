﻿using Ardalis.GuardClauses;
using ConAppPlayingWithGuards.Extensions;
using static System.Console;

namespace ConAppPlayingWithGuards;

public class Program
{
    static async Task Main()
    {
        WriteLine("Hello, World!");
        TestGuard();
        CreatePersonWithoutGuard("John", 17);
        CreatePerson("John", 17);



        await Task.CompletedTask;
    }

    private static void TestGuard()
    {
        var age = 17;
        if (age < 18)
        {
            throw new Exception("You are not allowed to enter this site.");
        }
    }

    private static void CreatePersonWithoutGuard(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }

        if (age <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(age), "Age must be greater than 0.");
        }
    }

    private static void CreatePerson(string name, int age)
    {
        //if (string.IsNullOrWhiteSpace(name))
        //{
        //    throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        //}
        Guard.Against.NullOrWhiteSpace(name, nameof(name));

        //if (age <= 0)
        //{
        //    throw new ArgumentOutOfRangeException(nameof(age), "Age must be greater than 0.");
        //}
        Guard.Against.NegativeOrZero(age, nameof(age));

        // Add more Guard.Against.* examples... i.e. custom Guard
        Guard.Against.AgainstInvalidAge(age, nameof(age));
    }
}

// Scenario:
/*
 * This is a case of building an e-commerce application where you need to validate an order before processing it. The order has several properties like OrderDate, Customer, and a list of OrderItems. You want to ensure:
 *
 * The OrderDate is not in the future.
 * The Customer is not null and has a valid CustomerId.
 * The OrderItems list is not empty, and each item has a valid ProductId and a quantity greater than zero.
 * 
 */
