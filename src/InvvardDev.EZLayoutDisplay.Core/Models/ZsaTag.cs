using Newtonsoft.Json;

namespace InvvardDev.EZLayoutDisplay.Core.Models
{
    public class ZsaTag
    {
        /// <summary>
        /// Gets or sets the tag name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}