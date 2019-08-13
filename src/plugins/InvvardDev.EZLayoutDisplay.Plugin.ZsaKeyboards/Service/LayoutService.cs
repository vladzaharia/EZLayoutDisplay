using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;
using Newtonsoft.Json;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.Service
{
    public class LayoutService : ILayoutService
    {
        #region ILayoutService implementation

        /// <inheritdoc />
        public async Task<IEnumerable<KeyTemplate>> LoadLayoutDefinitionAsync(string filePath)
        {
            var fileContent = GetFileContent(filePath);

            IEnumerable<KeyTemplate> layoutTemplate = await ReadLayoutDefinition(fileContent);

            return layoutTemplate;
        }

        /// <inheritdoc />
        public async Task<List<ObservableCollection<KeyTemplate>>> PopulateLayoutTemplatesAsync(List<KeyTemplate> layoutDefinition, EZLayout ezLayout)
        {
            var keyTemplates = new List<ObservableCollection<KeyTemplate>>();

            await Task.Run(() => {
                               foreach (var ezLayer in ezLayout.EZLayers)
                               {
                                   var clonedLayoutDefinition = layoutDefinition.Select(l => (KeyTemplate) l.Clone()).ToList();

                                   for (int j = 0 ; j < clonedLayoutDefinition.Count ; j++)
                                   {
                                       clonedLayoutDefinition[j].EZKey = ezLayer.EZKeys[j];
                                   }

                                   keyTemplates.Add(new ObservableCollection<KeyTemplate>(clonedLayoutDefinition));
                               }
                           });

            return keyTemplates;
        }

        #endregion

        #region Private methods

        private byte[] GetFileContent(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File {filePath} is missing. Install the plugin again to fix.");
            }

            var fileContent = File.ReadAllBytes(filePath);

            return fileContent;
        }

        private async Task<IEnumerable<KeyTemplate>> ReadLayoutDefinition(byte[] fileContent)
        {
            if (fileContent.Length <= 0)
            {
                return new List<KeyTemplate>();
            }

            var layoutTemplate = await Task.Run(() => {
                                                    var json = Encoding.Default.GetString(fileContent);

                                                    var layoutDefinition = JsonConvert.DeserializeObject<IEnumerable<KeyTemplate>>(json);

                                                    return layoutDefinition;
                                                });

            return layoutTemplate;
        }

        #endregion
    }
}