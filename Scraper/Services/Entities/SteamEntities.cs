using skroy.Scraper.Helpers;
using System.Text.Json.Serialization;

namespace skroy.Scraper.Services.Entities;

public class SteamResponse<T>
{
	[JsonPropertyName("response")]
	public T Response { get; set; }
	[JsonPropertyName("playerstats")]
	public T PlayerStats { get; set; }
}

public class GetOwnedGamesResponse
{
	[JsonPropertyName("game_count")]
	public long GameCount { get; set; }
	[JsonPropertyName("games")]
	public OwnedGame[] Games { get; set; }
}

public class OwnedGame
{
	[JsonPropertyName("appid")]
	public long AppId { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("img_icon_url")]
	public string ImgIconUrl { get; set; }
	[JsonPropertyName("playtime_2weeks")]
	public long RecentPlaytime { get; set; }
	[JsonPropertyName("playtime_forever")]
	public long Playtime { get; set; }
	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonPropertyName("rtime_last_played")]
	public DateTime? LastPlayed { get; set; }
}

public class GetPlayerAchievementsResponse
{
	[JsonPropertyName("success")]
	public bool Success { get; set; }
	[JsonPropertyName("achievements")]
	public Achievement[] Achievements { get; set; }
}

public class Achievement
{
	[JsonPropertyName("apiname")]
	public string ApiName { get; set; }
	[JsonConverter(typeof(BooleanConverter))]
	[JsonPropertyName("achieved")]
	public bool Achieved { get; set; }
	[JsonConverter(typeof(UnixDateTimeConverter))]
	[JsonPropertyName("unlocktime")]
	public DateTime? UnlockTime { get; set; }
}

public class GetRecentlyPlayedGamesResponse
{
	[JsonPropertyName("total_count")]
	public long GameCount { get; set; }
	[JsonPropertyName("games")]
	public OwnedGame[] Games { get; set; }
}

public class GetPlayerSummariesResponse
{
	[JsonPropertyName("players")]
	public Player[] Players { get; set; }
}

public class Player
{
	[JsonPropertyName("personaname")]
	public string Name { get; set; }
	[JsonPropertyName("profileurl")]
	public string ProfileUrl { get; set; }
	[JsonPropertyName("avatarfull")]
	public string AvatarUrl { get; set; }
	[JsonPropertyName("gameid")]
	public long? CurrentGame { get; set; }
}