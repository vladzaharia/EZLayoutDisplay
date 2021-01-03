using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Core.Helper;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NLog;

namespace InvvardDev.EZLayoutDisplay.Core.Services.Implementation
{
    public class WindowService : MvxNavigationService
    {
        private static readonly Logger       Logger = LogManager.GetCurrentClassLogger();
        private readonly        List<string> _windows;

        public WindowService(IMvxNavigationCache navigationCache, IMvxViewModelLoader viewModelLoader) : base(navigationCache, viewModelLoader)
        {
            Logger.TraceConstructor();
            _windows = new List<string>();
        }

        public override Task<bool> Navigate<TViewModel>(IMvxBundle presentationBundle = null, CancellationToken cancellationToken = new CancellationToken())
        {
            _windows.Add(typeof(TViewModel).ToString());

            return base.Navigate<TViewModel>(presentationBundle, cancellationToken);
        }

        public override Task<bool> Close(IMvxViewModel viewModel, CancellationToken cancellationToken = new CancellationToken())
        {
            var windowKey = viewModel.GetType().ToString();

            if (_windows.Contains(windowKey)) { _windows.Remove(windowKey); }

            return base.Close(viewModel, cancellationToken);
        }

        public bool ShowWarning(string warningMessage)
        {
            Logger.TraceMethod();

            var result = MessageBox.Show(warningMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK;

            Logger.DebugOutputParam(nameof(result), result);

            return result;
        }
    }
}