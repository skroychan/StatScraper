using Scraper.Helpers;

namespace Scraper.Configurations;

public abstract class Configuration
{
	public readonly ScraperType scraperType;
    public readonly string UserId;


    public Configuration(ScraperType type)
	{
        scraperType = type;
		UserId = ConfigHelper.GetUserId(scraperType);
	}
}
