﻿using System.Collections.Generic;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.Service
{
    public interface ILayoutService
    {
        /// <summary>
        /// Loads the list of <see cref="KeyTemplate"/> from the local repository.
        /// </summary>
        /// <param name="filePath">The file path to load the list of <see cref="KeyTemplate"/> from.</param>
        /// <returns>An <see cref="IEnumerable{KeyTemplate}"/></returns>
        Task<IEnumerable<KeyTemplate>> LoadLayoutDefinitionAsync(string filePath);

        /// <summary>
        /// Populates the layout templates with <see cref="EZLayout"/> keys.
        /// </summary>
        /// <param name="layoutDefinition">The keyboard key layout definition.</param>
        /// <param name="ezLayout">The <see cref="EZLayout"/> to get the key value from.</param>
        /// <returns></returns>
        Task<List<List<KeyTemplate>>> PopulateLayoutTemplatesAsync(List<KeyTemplate> layoutDefinition, EZLayout ezLayout);
    }
}