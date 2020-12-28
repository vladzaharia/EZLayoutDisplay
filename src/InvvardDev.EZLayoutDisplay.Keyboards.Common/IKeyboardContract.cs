using System.Collections.Generic;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Enum;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Model;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Common
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
        /// Switches to another layer.
        /// </summary>
        /// <param name="direction">The direction to switch the layer to.</param>
        void SwitchLayer(SwitchDirection direction);
    }
}
