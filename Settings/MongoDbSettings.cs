namespace CurrencyIndexApi.Settings;

public class MongoDbSettings
{
    public string Host { get; set; } = null!;
    public string Port { get; set; } = null!;

    public string ConnectionString
    {
        get
        {
            return $"mongodb://{Host}:{Port}";
        }
    }
}