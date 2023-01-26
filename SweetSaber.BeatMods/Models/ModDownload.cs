using System.Text.Json.Serialization;

namespace SweetSaber.BeatMods.Models
{
    public class ModDownload
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        [JsonPropertyName("hashMd5")]
        public List<ModMD5Hash> HashMd5 { get; set; } = null!;
    }
}
