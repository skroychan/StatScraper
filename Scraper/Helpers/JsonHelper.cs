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
		writer.WriteNumberValue((long)(value - DateTime.UnixEpoch)?.TotalSeconds);
	}
}

public class BooleanConverter : JsonConverter<bool>
{
	public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return reader.GetInt64() != 0;
	}

	public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
	{
		writer.WriteNumberValue(value ? 1 : 0);
	}
}