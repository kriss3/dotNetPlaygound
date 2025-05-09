namespace ConAppFunctional.BaseModels;
public record DiscountResult 
{ 
	public decimal DiscountAmount { get; init; } 
}

public class DiscountError { public string? Reason { get; set; } }