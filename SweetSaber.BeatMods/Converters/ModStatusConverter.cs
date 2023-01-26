using System.Text.Json;
using System.Text.Json.Serialization;

namespace SweetSaber.BeatMods.Converters
{
    internal class ModStatusConverter : JsonConverter<ModStatus>
    {
        public override ModStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => reader.GetString() == "approved" ? ModStatus.Approved : ModStatus.Inactive;

        public override void Write(Utf8JsonWriter writer, ModStatus value, JsonSerializerOptions options)
            => throw new NotImplementedException();
    }
}
