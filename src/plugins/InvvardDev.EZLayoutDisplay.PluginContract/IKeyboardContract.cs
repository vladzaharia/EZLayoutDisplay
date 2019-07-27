using System.Collections.Generic;

namespace InvvardDev.EZLayoutDisplay.PluginContract
{
    public interface IKeyboardContract
    {
        /// <summary>
        /// Gets or sets the list of supported keyboard model.
        /// </summary>
        IEnumerable<string> SupportedKeyboardModel { get; }

        /// <summary>
        /// Gets the current layer name.
        /// </summary>
        /// <returns>The current layer name.</returns>
        string GetCurrentLayerName();


    }
}
