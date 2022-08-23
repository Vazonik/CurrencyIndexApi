using CurrencyIndexApi.Dtos;
using CurrencyIndexApi.Models;
using CurrencyIndexApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyIndexApi.Controllers;

[ApiController]
[Route("currencies")]
public class CurrenciesController : ControllerBase
{
    private readonly CurrenciesRepository _currenciesRepository;

    public CurrenciesController(CurrenciesRepository currenciesRepository)
    {
        _currenciesRepository = currenciesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Currency>>> GetCurrencies()
    {
        var currencies = await _currenciesRepository.GetAllAsync();
        return Ok(currencies);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCurrency(Currency currency)
    {
        await _currenciesRepository.CreateAsync(currency);
        return CreatedAtAction(nameof(GetCurrencies), new { id = currency.Id }, currency.AsDto());
    }
}