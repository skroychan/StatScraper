using System.Text.Json.Serialization;
using System.Text.Json;

namespace Scraper.Helpers;

public static class JsonHelper
{
	
}

public class UnixDateTimeConverter : JsonConverter<DateTime?>
{
	public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var value = reader.GetInt64();
		return value == 0 ? null : DateTime.UnixEpoch.AddSeconds(value);
	}

	public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
	{
		writer.WriteStringValue((value - DateTime.UnixEpoch)?.TotalSeconds.ToString());
	}
}
