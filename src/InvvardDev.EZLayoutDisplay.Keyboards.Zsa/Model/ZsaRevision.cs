using System.Collections.Generic;
using Newtonsoft.Json;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa.Model
{
    public class ZsaRevision
    {
        /// <summary>
        /// Gets or sets the zsaRevision hash identifier.
        /// </summary>
        [JsonProperty("hashId")]
        public string HashId { get; set; }

        /// <summary>
        /// Gets or sets the keyboard zsaRevision comment.
        /// </summary>
        [JsonProperty("title")]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the keyboard model.
        /// </summary>
        [JsonProperty("model")]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the keyboard layout HEX file URL.
        /// </summary>
        [JsonProperty("hexUrl")]
        public string HexUrl { get; set; }

        /// <summary>
        /// Gets or sets the keyboard layout sources zip URL.
        /// </summary>
        [JsonProperty("zipUrl")]
        public string SourcesUrl { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="ZsaLayer"/>.
        /// </summary>
        [JsonProperty("layers")]
        public List<ZsaLayer> Layers { get; set; }
    }
}