using Newtonsoft.Json;
using Portal2Boards.Extensions;

namespace nekzor.github.io
{
    internal class ScoreEntry
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }
        [JsonProperty("mode")]
        public Portal2MapType Mode { get; set; }
        [JsonProperty("score")]
        public decimal Score { get; set; }
    }
}
