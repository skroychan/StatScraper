using skroy.Scraper.Entities.Base;

namespace skroy.Scraper.Scrapers;

public abstract class Scraper
{
    public abstract IEnumerable<Entry> Scrape(bool full = false);
    public abstract User GetUser();
}
