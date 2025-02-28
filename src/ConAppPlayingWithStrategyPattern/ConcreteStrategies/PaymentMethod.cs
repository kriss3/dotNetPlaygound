namespace ConAppPlayingWithStrategyPattern.ConcreteStrategies;
public abstract record PaymentMethod;

public sealed record CreditCard: PaymentMethod;
public sealed record PayPal : PaymentMethod;
public sealed record Bitcoin : PaymentMethod;
