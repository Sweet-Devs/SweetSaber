using System.Text.Json.Serialization;

namespace SweetSaber.BeatMods.Models
{
    public class ModAuthor
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("username")]
        public string Username { get; set; } = null!;

        [JsonPropertyName("lastLogin")]
        public DateTime? LastLogin { get; set; }
    }
}
