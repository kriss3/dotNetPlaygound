using Ardalis.GuardClauses;
using ConAppPlayingWithGuards.Models;

namespace ConAppPlayingWithGuards.Extensions;

public static class GuardClauseExtensions
{
    public static void AgainstInvalidAge(this IGuardClause guardClause, int age, string parameterName)
    {
        if (age <= 0 || age > 120)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Age must be between 1 and 120.");
        }
    }


    public static void ValidOrder(this IGuardClause guardClause, Order order, string parameterName)
    {
        Guard.Against.Null(order, parameterName);
        guardClause.NotInTheFuture(order.OrderDate, nameof(order.OrderDate));
        guardClause.ValidCustomer(order.Customer, nameof(order.Customer));
        Guard.Against.NullOrEmpty(order.OrderItems, nameof(order.OrderItems));

        foreach (var item in order.OrderItems)
        {
            guardClause.ValidOrderItem(item, nameof(order.OrderItems));
        }
    }

    public static void InTheFuture(this IGuardClause guardClause, 
        DateTime input, string parameterName)
    {
        if (input > DateTime.Now)
        {
            throw new ArgumentException($"Input {parameterName} cannot be in the future.", parameterName);
        }
    }

    public static void InvalidCustomer(this IGuardClause guardClause, 
        Customer customer, string parameterName)
    {
        Guard.Against.Null(customer, parameterName);
        Guard.Against.Default(customer.CustomerId, nameof(customer.CustomerId));
    }


    public static void ValidCustomer(this IGuardClause guardClause, 
        Customer customer, string parameterName)
    {
        Guard.Against.Null(customer, parameterName);
        Guard.Against.Default(customer.CustomerId, nameof(customer.CustomerId));
    }

    public static void ValidOrderItem(this IGuardClause guardClause, 
        OrderItem orderItem, string parameterName)
    {
        Guard.Against.Null(orderItem, parameterName);
        Guard.Against.Default(orderItem.ProductId, nameof(orderItem.ProductId));
        Guard.Against.OutOfRange(orderItem.Quantity, nameof(orderItem.Quantity), 1, int.MaxValue);
    }

    public static void NotInTheFuture(this IGuardClause guardClause, DateTime input, string parameterName)
    {
        if (input > DateTime.Now)
        {
            throw new ArgumentException($"Input {parameterName} cannot be in the future.", parameterName);
        }
    }
}

