using System.Collections.Generic;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Desktop.Model;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.CommonZsa.Service
{
    internal interface ILayoutService
    {
        /// <summary>
        /// Gets the list of <see cref="KeyTemplate"/> from the local repository.
        /// </summary>
        /// <param name="filePath">The file path to load the list of <see cref="KeyTemplate"/> from.</param>
        /// <returns>An <see cref="IEnumerable{KeyTemplate}"/></returns>
        Task<IEnumerable<KeyTemplate>> GetLayoutTemplate(string filePath);
    }
}