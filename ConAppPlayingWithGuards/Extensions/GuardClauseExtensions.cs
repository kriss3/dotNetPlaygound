using Ardalis.GuardClauses;

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

    public static void AgainstInvalidOrder(this IGuardClause guardClause, Order order, string parameterName)
    {
        Guard.Against.Null(order, parameterName);
        Guard.Against.InTheFuture(order.OrderDate, nameof(order.OrderDate));
        Guard.Against.InvalidCustomer(order.Customer, nameof(order.Customer));
        Guard.Against.Empty(order.OrderItems, nameof(order.OrderItems));

        foreach (var item in order.OrderItems)
        {
            Guard.Against.InvalidOrderItem(item, nameof(order.OrderItems));
        }

    }

    public static void InTheFuture(this IGuardClause guardClause, DateTime input, string parameterName)
    {
        if (input > DateTime.Now)
        {
            throw new ArgumentException($"Input {parameterName} cannot be in the future.", parameterName);
        }
    }
}
