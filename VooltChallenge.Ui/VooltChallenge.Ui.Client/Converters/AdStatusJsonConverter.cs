using System.Text.Json.Serialization;
using System.Text.Json;
using VooltChallenge.Shared;

namespace VooltChallenge.Ui.Client.Converters;

public sealed class AdStatusJsonConverter : JsonConverter<AdStatus>
{
    public override AdStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (Enum.TryParse<AdStatus>(value, out var status))
            return status;

        throw new JsonException($"Unknown AdStatus value: {value}");
    }

    public override void Write(Utf8JsonWriter writer, AdStatus value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
