using CurrencyIndexApi.Models;

namespace CurrencyIndexApi.Dtos;

public record CurrencyDto(
    string Id,
    string Name
);

public static partial class Extensions
{
    public static CurrencyDto AsDto(this Currency currency)
    {
        return new CurrencyDto(
            currency.Id,
            currency.Name
        );
    }
}