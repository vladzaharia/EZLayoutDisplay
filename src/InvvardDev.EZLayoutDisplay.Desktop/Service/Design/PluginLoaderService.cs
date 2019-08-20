using System.Collections.Generic;
using InvvardDev.EZLayoutDisplay.Desktop.Service.Interface;

namespace InvvardDev.EZLayoutDisplay.Desktop.Service.Design
{
    public class PluginLoaderService<T> : IPluginLoader<T>
    {
        public IEnumerable<T> Plugins { get; set; }

        public void Dispose()
        {
        }
    }
}