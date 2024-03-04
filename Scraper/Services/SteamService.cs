using skroy.Scraper.Configurations;
using skroy.Scraper.Helpers;
using skroy.Scraper.Services.Base;
using skroy.Scraper.Services.Entities;

namespace skroy.Scraper.Services;

public class SteamService : ApiService<SteamConfiguration>
{
	public OwnedGame[] GetOwnedGames(bool includeAppInfo = true, bool includePlayedFreeGames = true)
	{
		var args = new Dictionary<string, string>
		{
			{ "key", Configuration.ApiKey },
			{ "steamid", Configuration.UserId },
			{ "include_appinfo", includeAppInfo.ToString() },
			{ "include_played_free_games", includePlayedFreeGames.ToString() }
		};
		var url = HttpHelper.BuildUrl(args, "http://api.steampowered.com/", "IPlayerService", "GetOwnedGames", "v0001");

		return GetResponse<GetOwnedGamesResponse>(url).Games;
	}

	public Achievement[] GetPlayerAchievements(long appId)
	{
		var args = new Dictionary<string, string>
		{
			{ "key", Configuration.ApiKey },
			{ "steamid", Configuration.UserId },
			{ "appid", appId.ToString() }
		};
		var url = HttpHelper.BuildUrl(args, "http://api.steampowered.com/", "ISteamUserStats", "GetPlayerAchievements", "v0001");

		var response = GetResponse<GetPlayerAchievementsResponse>(url);
		return response.Success ? response.Achievements : [];
	}

	public OwnedGame[] GetRecentlyPlayedGames()
	{
		var args = new Dictionary<string, string>
		{
			{ "key", Configuration.ApiKey },
			{ "steamid", Configuration.UserId }
		};
		var url = HttpHelper.BuildUrl(args, "http://api.steampowered.com/", "IPlayerService", "GetRecentlyPlayedGames", "v0001");

		return GetResponse<GetRecentlyPlayedGamesResponse>(url).Games;
	}

	public Player GetPlayerSummary()
	{
		return GetPlayerSummaries(Configuration.UserId)[0];
	}

	public Player[] GetPlayerSummaries(params string[] steamIds)
	{
		var args = new Dictionary<string, string>
		{
			{ "key", Configuration.ApiKey },
			{ "steamids", string.Join(',', steamIds) }
		};
		var url = HttpHelper.BuildUrl(args, "http://api.steampowered.com/", "ISteamUser", "GetPlayerSummaries", "v0002");

		return GetResponse<GetPlayerSummariesResponse>(url).Players;
	}


	private static T GetResponse<T>(string url)
	{
		var result = HttpHelper.GetResponseAsync<SteamResponse<T>>(url).Result;
		return result.Response ?? result.PlayerStats;
	}
}
