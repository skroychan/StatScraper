using skroy.Scraper.Helpers;

namespace skroy.Scraper.Configurations;

public abstract class Configuration
{
	public ScraperType ScraperType { get; }
    public string UserId { get; }


    public Configuration(ScraperType type)
	{
        ScraperType = type;
		UserId = ConfigHelper.GetUserId(ScraperType);
	}
}
