using Newtonsoft.Json;

namespace InvvardDev.EZLayoutDisplay.Core.Models
{
    public class DataRoot
    {
        [JsonProperty("data")]
        public ZsaLayoutRoot LayoutRoot { get; set; }
    }

    public class ZsaLayoutRoot
    {
        [JsonProperty("Layout")]
        public ZsaLayout Layout { get; set; }
    }
}