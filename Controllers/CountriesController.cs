using CurrencyIndexApi.Dtos;
using CurrencyIndexApi.Models;
using CurrencyIndexApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyIndexApi.Controllers;

[ApiController]
[Route("countries")]
public class CountriesController : ControllerBase
{
    private readonly CountriesRepository _countriesRepository;
    private readonly CurrenciesRepository _currenciesRepository;

    public CountriesController(CountriesRepository countriesRepository, CurrenciesRepository currenciesRepository)
    {
        _countriesRepository = countriesRepository;
        _currenciesRepository = currenciesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
    {
        var countries = await _countriesRepository.GetAllAsync();
        return Ok(countries.Select(country => country.AsDto(_currenciesRepository)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCountry(Country country)
    {
        await _countriesRepository.CreateAsync(country);
        return CreatedAtAction(nameof(GetCountries), new { id = country.Id }, country.AsDto(_currenciesRepository));
    }
}