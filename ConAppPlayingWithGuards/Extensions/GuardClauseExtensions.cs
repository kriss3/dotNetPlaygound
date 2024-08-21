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
}
