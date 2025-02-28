using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppPlayingWithStrategyPattern.ConcreteStrategies;
public abstract record PaymentMethod;

public sealed record CreditCard: PaymentMethod;
public sealed record PayPal : PaymentMethod;
public sealed record Bitcoin : PaymentMethod;
