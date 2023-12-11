using Scraper.Entities;
using Scraper.Services;

namespace Scraper.Scrapers;

public class SteamScraper : Scraper
{
	private readonly SteamService steamService;


    public SteamScraper()
    {
		steamService = new SteamService();
    }


    public override IEnumerable<Entry> Scrape(bool full = false)
	{
		var result = new List<SteamEntry>();

		var games = steamService.GetOwnedGames();
		foreach (var game in games)
		{
			var achievements = steamService.GetPlayerAchievements(game.AppId);
			var entry = new SteamEntry();

			entry.Id = game.AppId;
			entry.Title = game.Name;
			entry.LastScrapedDate = DateTime.Now;
			entry.UpdatedDate = game.LastPlayed;
			entry.Playtime = game.Playtime;
			entry.ImageHash = game.ImgIconUrl;
			entry.Achievements = achievements?.Count(x => x.Achieved);
			entry.TotalAchievements = achievements?.Length;

			result.Add(entry);
		}

		return result;
	}

	public override User GetUser()
	{
		var result = new SteamUser();

		var user = steamService.GetPlayerSummary();
		result.Name = user.Name;
		result.ProfileUrl = user.ProfileUrl;
		result.AvatarUrl = user.AvatarUrl;
		result.CurrentGame = user.CurrentGame;

		return result;
	}
}