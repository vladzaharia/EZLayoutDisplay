using System.Windows;
using InvvardDev.EZLayoutDisplay.Desktop.Service.Interface;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Helper;
using NLog;

namespace InvvardDev.EZLayoutDisplay.Desktop.Service.Implementation
{
    public class ApplicationService : IApplicationService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <inheritdoc />
        public void ShutdownApplication()
        { 
            Logger.TraceMethod();
            Application.Current.Shutdown();
        }
    }
}