using Scraper.Helpers;

namespace Scraper.Configurations;

public class ApiConfiguration : Configuration
{
	public readonly string ApiKey;


	public ApiConfiguration(ScraperType type) : base(type)
	{
		ApiKey = ConfigHelper.GetApiKey(scraperType);
	}
}
