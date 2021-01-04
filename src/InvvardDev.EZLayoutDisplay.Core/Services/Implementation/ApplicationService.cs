using InvvardDev.EZLayoutDisplay.Core.Helper;
using InvvardDev.EZLayoutDisplay.Core.Services.Interface;
using NLog;

namespace InvvardDev.EZLayoutDisplay.Core.Services.Implementation
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