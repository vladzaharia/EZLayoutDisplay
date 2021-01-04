using InvvardDev.EZLayoutDisplay.Core.Helper;
using InvvardDev.EZLayoutDisplay.Core.Services.Interface;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using NLog;

namespace InvvardDev.EZLayoutDisplay.Core.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class NotifyIconViewModel : MvxNavigationViewModel
    {
#region Fields

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private IMvxCommand _showLayoutCommand;
        private IMvxCommand _showSettingsCommand;
        private IMvxCommand _showAboutCommand;
        private IMvxCommand _exitCommand;

        private readonly IApplicationService _applicationService;

        private string _trayMenuShowLayoutCommandLabel;
        private string _trayMenuShowLayoutShortcutLabel;
        private string _trayMenuShowSettingsCommandLabel;
        private string _trayMenuShowAboutCommandLabel;
        private string _trayMenuExitCommandLabel;

#endregion

#region Public properties

        public string TrayMenuShowLayoutCommandLabel
        {
            get => _trayMenuShowLayoutCommandLabel;
            set => SetProperty(ref _trayMenuShowLayoutCommandLabel, value);
        }

        public string TrayMenuShowLayoutShortcutLabel
        {
            get => _trayMenuShowLayoutShortcutLabel;
            set => SetProperty(ref _trayMenuShowLayoutShortcutLabel, value);
        }

        public string TrayMenuShowSettingsCommandLabel
        {
            get => _trayMenuShowSettingsCommandLabel;
            set => SetProperty(ref _trayMenuShowSettingsCommandLabel, value);
        }

        public string TrayMenuShowAboutCommandLabel
        {
            get => _trayMenuShowAboutCommandLabel;
            set => SetProperty(ref _trayMenuShowAboutCommandLabel, value);
        }

        public string TrayMenuExitCommandLabel
        {
            get => _trayMenuExitCommandLabel;
            set => SetProperty(ref _trayMenuExitCommandLabel, value);
        }

#endregion

#region Relay commands

        /// <summary>
        /// Shows the Layout window.
        /// </summary>
        public IMvxCommand ShowLayoutCommand => _showLayoutCommand ??= new MvxCommand(ShowLayoutWindow);

        /// <summary>
        /// Shows the Settings Window.
        /// </summary>
        public IMvxCommand ShowSettingsCommand => _showSettingsCommand ??= new MvxCommand(ShowSettingsWindow);

        /// <summary>
        /// Shows the About Window.
        /// </summary>
        public IMvxCommand ShowAboutCommand => _showAboutCommand ??= new MvxCommand(ShowAboutWindow);

        /// <summary>
        /// Shuts down the application.
        /// </summary>
        public IMvxCommand ExitApplicationCommand => _exitCommand ??= new MvxCommand(ShutdownApplication);

#endregion

#region Constructor

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public NotifyIconViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IApplicationService applicationService)
            : base(logProvider, navigationService)
        {
            Logger.TraceConstructor();

            _applicationService = applicationService;

            SetLabelUi();
        }

        private void SetLabelUi()
        {
            TrayMenuShowLayoutCommandLabel = "Show Layout";
            TrayMenuShowLayoutShortcutLabel = "Hyper+Space";
            TrayMenuShowSettingsCommandLabel = "Settings";
            TrayMenuShowAboutCommandLabel = "About";
            TrayMenuExitCommandLabel = "Exit";
        }

#endregion

#region Private methods

        private void ShowLayoutWindow()
        {
            Logger.TraceCommand();
            NavigationService.Navigate<DisplayLayoutViewModel>();
        }

        private void ShowSettingsWindow()
        {
            Logger.TraceCommand();
            NavigationService.Navigate<SettingsViewModel>();
        }

        private void ShowAboutWindow()
        {
            Logger.TraceCommand();
            NavigationService.Navigate<AboutViewModel>();
        }

        private void ShutdownApplication()
        {
            Logger.TraceCommand();
            _applicationService.ShutdownApplication();
        }

#endregion
    }
}