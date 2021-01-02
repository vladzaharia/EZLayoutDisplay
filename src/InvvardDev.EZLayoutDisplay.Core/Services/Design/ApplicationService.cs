using System.Diagnostics;
using InvvardDev.EZLayoutDisplay.Core.Services.Interface;

namespace InvvardDev.EZLayoutDisplay.Core.Services.Design
{
    public class ApplicationService : IApplicationService
    {
        /// <inheritdoc />
        public void ShutdownApplication()
        {
            Debug.WriteLine("Application is closing.");
        }
    }
}