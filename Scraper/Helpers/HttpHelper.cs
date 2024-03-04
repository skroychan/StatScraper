using System.Text.Json;

namespace skroy.Scraper.Helpers;

public static class HttpHelper
{
	public static string BuildUrl(Dictionary<string, string> args, string baseUrl, params string[] urlParts)
		=> $"{string.Join('/', baseUrl.TrimEnd('/'), string.Join('/', urlParts))}?{BuildArgs(args)}";

	public static string BuildArgs(Dictionary<string, string> args)
		=> string.Join('&', args.Select(x => $"{x.Key}={x.Value}"));

	public static async Task<T> GetResponseAsync<T>(string url)
	{
		using var httpClient = new HttpClient();

		var response = await httpClient.GetAsync(url);
		return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
	}
}
