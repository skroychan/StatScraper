using skroy.Scraper.Entities;
using skroy.Scraper.Services;

namespace skroy.Scraper.Scrapers;

public class SteamScraper : Scraper
{
	private SteamService SteamService { get; }


	public SteamScraper()
	{
		SteamService = new SteamService();
	}


	public override IEnumerable<Entry> Scrape(bool full = false)
	{
		var result = new List<SteamEntry>();

		var games = SteamService.GetOwnedGames();
		foreach (var game in games)
		{
			var achievements = SteamService.GetPlayerAchievements(game.AppId);

			result.Add(new SteamEntry
			{
				Id = game.AppId,
				Title = game.Name,
				LastScrapedDate = DateTime.Now,
				UpdatedDate = game.LastPlayed,
				Playtime = game.Playtime,
				ImageUrl = $"http://media.steampowered.com/steamcommunity/public/images/apps/{game.AppId}/{game.ImgHash}.jpg",
				Achievements = achievements?.Count(x => x.Achieved),
				TotalAchievements = achievements?.Length
			});
		}

		return result;
	}

	public override User GetUser()
	{
		var user = SteamService.GetPlayerSummary();

		return new SteamUser
		{
			Name = user.Name,
			ProfileUrl = user.ProfileUrl,
			AvatarUrl = user.AvatarUrl,
			CurrentGame = user.CurrentGame
		};
	}
}