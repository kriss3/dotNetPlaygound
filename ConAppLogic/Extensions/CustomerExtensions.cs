﻿namespace ConAppLogic.Extensions;

public static class CustomerExtensions
{
    public static bool IsMedical(this Customer customer)
    {
        return customer?.IsMedical ?? false;
    }

    public static bool ValidatePatientLocation(this Customer customer) 
    {
        if (customer.IsMedical && !(customer?.BillingAddress?.StateCode =="MO")) {
            throw new PatientLocationInfoException("Patient Information and Billing Information mismatch.");
        }
        return true;
    }
}

public class PatientLocationInfoException(string message) : Exception(message)
{
}