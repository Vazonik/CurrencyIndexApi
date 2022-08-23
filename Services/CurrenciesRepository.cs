using CurrencyIndexApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CurrencyIndexApi.Services;

public class CurrenciesRepository
{
    private const string DatabaseName = "currency-index";
    private const string CollectionName = "currencies";

    private readonly IMongoCollection<Currency> _currenciesRepository;
    private readonly FilterDefinitionBuilder<Currency> _filterBuilder = Builders<Currency>.Filter;

    public CurrenciesRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(DatabaseName);
        _currenciesRepository = database.GetCollection<Currency>(CollectionName);
    }

    public async Task CreateAsync(Currency currency)
    {
        await _currenciesRepository.InsertOneAsync(currency);
    }

    public Currency GetOne(string id)
    {
        var filter = _filterBuilder.Eq(item => item.Id, id);
        return  _currenciesRepository.Find(filter).SingleOrDefault();
    }
    
    public async Task<Currency> GetOneAsync(string id)
    {
        var filter = _filterBuilder.Eq(item => item.Id, id);
        return await _currenciesRepository.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Currency>> GetAllAsync()
    {
        var countries = await (await _currenciesRepository.FindAsync(new BsonDocument())).ToListAsync();
        return countries;
    }
}