using CurrencyIndexApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CurrencyIndexApi.Services;

public class CountriesRepository
{
    private const string DatabaseName = "currency-index";
    private const string CollectionName = "countries";

    private readonly IMongoCollection<Country> _countriesCollection;
    private readonly FilterDefinitionBuilder<Country> _filterBuilder = Builders<Country>.Filter;

    public CountriesRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase(DatabaseName);
        _countriesCollection = database.GetCollection<Country>(CollectionName);
    }

    public async Task CreateAsync(Country country)
    {
        await _countriesCollection.InsertOneAsync(country);
    }

    public async Task<Country> GetOne(string id)
    {
        var filter = _filterBuilder.Eq(item => item.Id, id);
        return await _countriesCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        var countries = await (await _countriesCollection.FindAsync(new BsonDocument())).ToListAsync();
        return countries;
    }
}