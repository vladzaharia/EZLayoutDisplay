using System.Collections.Generic;
using Newtonsoft.Json;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa.Model
{
    public class ZsaLayout
    {
        /// <summary>
        /// Gets or sets the layout hash identifier.
        /// </summary>
        [JsonProperty("hashId")]
        public string HashId { get; set; }

        /// <summary>
        /// Gets or sets the keyboard geometry.
        /// </summary>
        [JsonProperty("geometry")]
        public string Geometry { get; set; }

        /// <summary>
        /// Gets or sets the layout title.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the keyboard tags.
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<ZsaTag> Tags { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ZsaRevision"/>.
        /// </summary>
        [JsonProperty("revision")]
        public ZsaRevision ZsaRevision { get; set; }
    }

    public class DataRoot
    {
        [JsonProperty("data")]
        public ErgodoxLayoutRoot LayoutRoot { get; set; }
    }

    public class ErgodoxLayoutRoot
    {
        [JsonProperty("Layout")]
        public ZsaLayout Layout { get; set; }
    }
}