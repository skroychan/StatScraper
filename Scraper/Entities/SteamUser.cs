using skroy.Scraper.Entities.Base;

namespace skroy.Scraper.Entities;

public class SteamUser : User
{
	public long? CurrentGame { get; set; }
}
