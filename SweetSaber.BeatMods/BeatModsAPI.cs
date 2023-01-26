using SweetSaber.BeatMods.Converters;
using SweetSaber.BeatMods.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace SweetSaber.BeatMods
{
    public class BeatModsAPI
    {
        private HttpClient _http;

        public BeatModsAPI()
        {
            _http = new HttpClient();
        }

        public async Task<List<string>?> GetVersions()
            => await _http.GetFromJsonAsync<List<string>>("https://versions.beatmods.com/versions.json");

        public async Task<List<BSMod>?> GetMods(string gameVersion, string search = "", ModStatus status = ModStatus.Approved, bool sort = true, SortDirection sortDirection = SortDirection.Ascending)
        {
            return await _http.GetFromJsonAsync<List<BSMod>>("https://beatmods.com/api/v1/mod" +
                $"?search={search}" +
                $"&status={status}" +
                $"&gameVersion={gameVersion}" +
                $"&sort={(sort ? 1 : 0)}" +
                $"&sortDirection={(byte)sortDirection}", 
                new JsonSerializerOptions { Converters = { new ModStatusConverter() } });
        }
    }

    public enum ModStatus
    {
        Approved,
        Inactive
    }

    public enum SortDirection
    {
        Ascending = 1,
        Descending = -1
    }
}