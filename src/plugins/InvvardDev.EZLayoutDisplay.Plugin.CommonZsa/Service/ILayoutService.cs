using System.Collections.Generic;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.CommonZsa.Service
{
    public interface ILayoutService
    {
        /// <summary>
        /// Loads the list of <see cref="KeyTemplate"/> from the local repository.
        /// </summary>
        /// <param name="filePath">The file path to load the list of <see cref="KeyTemplate"/> from.</param>
        /// <returns>An <see cref="IEnumerable{KeyTemplate}"/></returns>
        Task<IEnumerable<KeyTemplate>> LoadLayoutDefinitionAsync(string filePath);

        Task<IEnumerable<IEnumerable<KeyTemplate>>> PopulateLayoutTemplatesAsync(IEnumerable<KeyTemplate> layoutDefinition, EZLayout ezLayout);
    }
}