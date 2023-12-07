using System.Text.Json;
using System.Text.Json.Nodes;

namespace Scraper.Helpers;

public static class ConfigHelper
{
    private static readonly Dictionary<ScraperType, string> ApiKeys;
    private static readonly Dictionary<ScraperType, string> UserIds;


    static ConfigHelper()
    {
        var configJson = File.ReadAllText("config.json");
        var config = JsonSerializer.Deserialize<JsonNode>(configJson);
		ApiKeys = config["ApiKeys"].Deserialize<Dictionary<ScraperType, string>>();
		UserIds = config["UserIds"].Deserialize<Dictionary<ScraperType, string>>();
    }


    public static string GetApiKey(ScraperType scraper)
        => ApiKeys[scraper];

    public static string GetUserId(ScraperType scraper)
        => UserIds[scraper];
}

public enum ScraperType
{
    Steam,
}
