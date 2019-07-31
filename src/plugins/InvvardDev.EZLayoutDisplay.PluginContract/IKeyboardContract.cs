using System.Collections.Generic;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.PluginContract
{
    public interface IKeyboardContract
    {
        /// <summary>
        /// Gets or sets the list of supported keyboard model.
        /// </summary>
        IEnumerable<string> SupportedKeyboardModel { get; }

        /// <summary>
        /// Loads the submitted <see cref="EZLayout"/>.
        /// </summary>
        /// <param name="ezLayout">The <see cref="EZLayout"/> object to load.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task LoadLayoutAsync(EZLayout ezLayout);

        /// <summary>
        /// Gets the current layer name.
        /// </summary>
        /// <returns>The current layer name.</returns>
        string GetCurrentLayerName();

        /// <summary>
        /// Gets the keyboard view.
        /// </summary>
        /// <returns>A rendered Keyboard user control.</returns>
        object GetKeyboardView();
    }
}
