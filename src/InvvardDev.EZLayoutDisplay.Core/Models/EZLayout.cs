using System.Collections.Generic;

namespace InvvardDev.EZLayoutDisplay.Core.Models
{
    public class EZLayout
    {
        /// <summary>
        /// Gets or sets the layout hash identifier.
        /// </summary>
        public string HashId { get; set; }

        /// <summary>
        /// Gets or sets the layout name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the layout list of layers.
        /// </summary>
        public List<EZLayer> EZLayers { get; set; }

        public EZLayout()
        {
            EZLayers = new List<EZLayer>();
        }
    }
}