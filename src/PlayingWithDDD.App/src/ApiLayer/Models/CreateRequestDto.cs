namespace PlayingWithDDD.App.src.ApiLayer.Models;

public record CreateRequestDto
{
	public int CompanyId { get; init; }
	public Guid LocationId { get; init; }
}
