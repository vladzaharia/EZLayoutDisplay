using System.Diagnostics;
using InvvardDev.EZLayoutDisplay.Core.Services.Interface;

namespace InvvardDev.EZLayoutDisplay.Core.Services.Implementation
{
    // ReSharper disable once ClassNeverInstantiated.Global : Instantiated in ViewModelLocator
    public class ProcessService : IProcessService
    {
        public void StartWebUrl(string url)
        {
            Process.Start(url);
        }
    }
}