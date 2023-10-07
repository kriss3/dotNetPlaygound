using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppLogic.Extensions;

public static class CustomerExtensions
{
    public static bool IsMedical(this Customer customer)
    {
        return customer?.IsMedical ?? false;
    }

    public static bool ValidatePatientLocation(this Customer customer) 
    {
        if (customer.IsMedical && !(customer?.BillingAddress?.StateCode =="MO")) {
            throw new PatientLocationInfoException("Patient Information and Billing Infomation mismatch.");
        }
        return true;
    }
}

public class PatientLocationInfoException : Exception
{
    public PatientLocationInfoException(string message)
        : base(message)  { }
}