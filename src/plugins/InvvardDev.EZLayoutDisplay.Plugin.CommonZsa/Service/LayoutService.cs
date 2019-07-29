using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Desktop.Model;
using InvvardDev.EZLayoutDisplay.Desktop.Properties;
using Newtonsoft.Json;

namespace InvvardDev.EZLayoutDisplay.Plugin.CommonZsa.Service
{
    public class LayoutService : ILayoutService
    {
        /// <inheritdoc />
        public async Task<IEnumerable<KeyTemplate>> GetLayoutTemplate(string filePath)
        {
            var fileContent = GetFileContent(filePath);

            IEnumerable<KeyTemplate> layoutTemplate = await ReadLayoutDefinition(fileContent);

            return layoutTemplate;
        }

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

    }
}