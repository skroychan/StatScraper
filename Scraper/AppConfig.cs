using System.Text.Json;
using System.Text.Json.Nodes;

namespace skroy.Scraper;

public static class AppConfig
{
    private static readonly Dictionary<ScraperType, string> ApiKeys;
    private static readonly Dictionary<ScraperType, string> UserIds;

    public static readonly string ConnectionString;


    static AppConfig()
    {
        var configJson = File.ReadAllText("config.json");
        var config = JsonSerializer.Deserialize<JsonNode>(configJson);
        ApiKeys = config["ApiKeys"].Deserialize<Dictionary<ScraperType, string>>();
        UserIds = config["UserIds"].Deserialize<Dictionary<ScraperType, string>>();
        ConnectionString = config["Database"]["ConnectionString"].ToString();
    }


    public static string GetApiKey(ScraperType scraper)
        => ApiKeys[scraper];

    public static string GetUserId(ScraperType scraper)
        => UserIds[scraper];
}

public enum ScraperType
{
    Steam,
    MAL,
    RYM
}
