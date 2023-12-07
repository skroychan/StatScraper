using Scraper.Configurations;

namespace Scraper.Services.Base;

public abstract class ApiService<T> : Service<T> where T : Configuration, new()
{
}
