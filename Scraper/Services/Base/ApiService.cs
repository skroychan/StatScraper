using skroy.Scraper.Configurations;

namespace skroy.Scraper.Services.Base;

public abstract class ApiService<T> : Service<T> where T : Configuration, new()
{
}
