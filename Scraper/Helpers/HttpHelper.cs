using System.Text.Json;

namespace Scraper.Helpers;

public static class HttpHelper
{
	public static string BuildUrl(Dictionary<string, string> args, string baseUrl, params string[] urlParts)
		=> $"{string.Join('/', baseUrl.TrimEnd('/'), urlParts)}/{BuildArgs(args)}";

	public static string BuildArgs(Dictionary<string, string> args)
		=> string.Join('&', args.Select(x => $"{x.Key}={x.Value}"));

	public static T GetResponse<T>(string url)
	{
		using var httpClient = new HttpClient();

		var json = httpClient.GetStringAsync(url).Result;
		return JsonSerializer.Deserialize<T>(json);
	}
}
