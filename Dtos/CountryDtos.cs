using CurrencyIndexApi.Models;
using CurrencyIndexApi.Services;

namespace CurrencyIndexApi.Dtos;

public record CountryDto(
    string Id,
    string Name,
    string? Flag,
    CurrencyDto Currency
);

public static partial class Extensions
{
    public static CountryDto AsDto(this Country country, CurrenciesRepository currenciesRepository)
    {
        return new CountryDto(
            country.Id,
            country.Name,
            country.Flag,
             currenciesRepository.GetOne(country.CurrencyId).AsDto()
        );
    }
}