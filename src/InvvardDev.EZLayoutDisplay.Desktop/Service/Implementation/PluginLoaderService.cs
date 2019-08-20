using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using InvvardDev.EZLayoutDisplay.Desktop.Service.Interface;

namespace InvvardDev.EZLayoutDisplay.Desktop.Service.Implementation
{
    public class PluginLoaderService<T> : IDisposable, IPluginLoader<T>
    {
        private readonly CompositionContainer _container;

        [ImportMany]
        public IEnumerable<T> Plugins { get; set; }

        public PluginLoaderService(string path)
        {
            var catalog = new DirectoryCatalog(path);

            _container = new CompositionContainer(catalog);
            _container.ComposeParts(this);
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}