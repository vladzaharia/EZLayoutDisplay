using Newtonsoft.Json;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa.Model
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