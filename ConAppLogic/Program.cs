﻿
using ConAppLogic.Extensions;
using static System.Console;

// See https://aka.ms/new-console-template for more information
WriteLine("Hello, World!");

Customer cust1 = new()
{
    Id = 1,
    IsMedical = true,
    BillingAddress = new Address() { StateCode = "MO" }, 
    MedicalInfo = new MedicalInformation() { MedicalCard = "PAT123456"}
};

if (cust1.IsMedical && cust1.ValidatePatientLocation())
    WriteLine("Customer is from the IN-State");
else
    WriteLine("Out-of-State customer");

public class Customer 
{
    public int Id { get; set; }
    public bool IsMedical { get; set; }
    public MedicalInformation? MedicalInfo { get; set; }
    public Address? BillingAddress { get; set; }
}



public class Address
{
    public string? StateCode { get; set; }
}

public class MedicalInformation
{
    public string? MedicalCard { get; set; }
}

public readonly struct Option<T>
{
    private readonly T? value;
    public bool HasValue { get; }

    private Option(T? value, bool hasValue)
    {
        this.value = value;
        HasValue = hasValue;
    }

    public T? Value
    {
        get
        {
            if (!HasValue)
                throw new InvalidOperationException("Optional object must have a value.");

            return value;
        }
    }

    public static Option<T> FromNullable(T value)
    {
        if (value == null)
            return new Option<T>(default, false);

        return new Option<T>(value, true);
    }
}





