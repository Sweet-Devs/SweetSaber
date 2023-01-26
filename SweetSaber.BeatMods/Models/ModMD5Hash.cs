using System.Text.Json.Serialization;

namespace SweetSaber.BeatMods.Models
{
    public class ModMD5Hash
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; } = null!;

        [JsonPropertyName("file")]
        public string File { get; set; } = null!;
    }
}
