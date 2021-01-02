using System.Collections.Generic;
using Newtonsoft.Json;

namespace InvvardDev.EZLayoutDisplay.Core.Models
{
    public class ZsaLayer
    {
        /// <summary>
        /// Gets or sets the layer hash identifier.
        /// </summary>
        [JsonProperty("hashId")]
        public string HashId { get; set; }

        /// <summary>
        /// Gets or sets the layer's list of <see cref="ZsaKey"/>.
        /// </summary>
        [JsonProperty("keys")]
        public List<ZsaKey> Keys { get; set; }

        /// <summary>
        /// Gets or sets the layer's position.
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// Gets or sets the layer's title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the layer's color.
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; }

        public override string ToString()
        {
            return $"{Title} {Position}";
        }
    }
}