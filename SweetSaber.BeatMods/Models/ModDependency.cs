using System.Text.Json.Serialization;

namespace SweetSaber.BeatMods.Models
{
    public class ModDependency
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; } = null!;

        [JsonPropertyName("version")]
        public string Version { get; set; } = null!;

        [JsonPropertyName("gameVersion")]
        public string GameVersion { get; set; } = null!;

        [JsonPropertyName("link")]
        public string Link { get; set; } = null!;

        [JsonPropertyName("updatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [JsonPropertyName("uploadDate")]
        public DateTime? UploadDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        [JsonPropertyName("downloads")]
        public List<ModDownload> Downloads { get; set; } = null!;

        [JsonPropertyName("category")]
        public string Category { get; set; } = null!;

        [JsonPropertyName("required")]
        public bool? Required { get; set; }

        [JsonPropertyName("dependencies")]
        public List<string> Dependencies { get; set; } = null!;
    }
}
