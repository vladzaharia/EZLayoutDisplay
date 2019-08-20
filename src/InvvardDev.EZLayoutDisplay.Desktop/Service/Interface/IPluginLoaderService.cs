using System.Collections.Generic;

namespace InvvardDev.EZLayoutDisplay.Desktop.Service.Interface
{
    public interface IPluginLoader<T>
    {
        IEnumerable<T> Plugins { get; set; }

        void Dispose();
    }
}