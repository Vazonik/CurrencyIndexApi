namespace CurrencyIndexApi.Models;

public record Country
{
    public string Id { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string? Flag { get; init; }
    public string CurrencyId { get; init; } = null!;
}