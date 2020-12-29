using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using InvvardDev.EZLayoutDisplay.Desktop.Model.Messenger;
using InvvardDev.EZLayoutDisplay.Desktop.Service.Interface;
using InvvardDev.EZLayoutDisplay.Desktop.View;
using InvvardDev.EZLayoutDisplay.Keyboards.Common;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Enum;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Helper;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Model;
using NLog;

namespace InvvardDev.EZLayoutDisplay.Desktop.ViewModel
{
    public class DisplayLayoutViewModel : ViewModelBase
    {
#region Fields

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly IWindowService    _windowService;
        private readonly ILayoutService    _layoutService;
        private readonly ISettingsService  _settingsService;
        private          IKeyboardContract _keyboard;

        private ICommand _lostFocusCommand;
        private ICommand _hideWindowCommand;
        private ICommand _nextLayerCommand;
        private ICommand _scrollLayerCommand;

        private object _keyboardView;

        private bool _isWindowPinned;

        private string _windowTitle;
        private string _noLayoutWarningFirstLine;
        private string _noLayoutWarningSecondLine;
        private string _currentLayerNameTitle;
        private string _currentLayerName;
        private string _controlHintSpaceLabel;
        private string _controlHintEscapeLabel;
        private string _toggleBtnPinWindowContent;
        private string _toggleBtnPinWindowTooltip;
        private bool   _noLayoutAvailable;

#endregion

#region Properties

        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        public string WindowTitle
        {
            get => _windowTitle;
            private set => Set(ref _windowTitle, value);
        }

        /// <summary>
        /// Gets or sets the no layout warning first line.
        /// </summary>
        public string NoLayoutWarningFirstLine
        {
            get => _noLayoutWarningFirstLine;
            private set => Set(ref _noLayoutWarningFirstLine, value);
        }

        /// <summary>
        /// Gets or sets the no layout warning second line.
        /// </summary>
        public string NoLayoutWarningSecondLine
        {
            get => _noLayoutWarningSecondLine;
            private set => Set(ref _noLayoutWarningSecondLine, value);
        }

        /// <summary>
        /// Gets or sets the current layer name title.
        /// </summary>
        public string CurrentLayerNameTitle
        {
            get => _currentLayerNameTitle;
            private set => Set(ref _currentLayerNameTitle, value);
        }

        /// <summary>
        /// Gets or sets the current layer name.
        /// </summary>
        public string CurrentLayerName
        {
            get => _currentLayerName;
            private set => Set(ref _currentLayerName, value);
        }

        /// <summary>
        /// Gets or sets the control hint label for the Space bar.
        /// </summary>
        public string ControlHintSpaceLabel
        {
            get => _controlHintSpaceLabel;
            private set => Set(ref _controlHintSpaceLabel, value);
        }

        /// <summary>
        /// Gets or sets the control hint label for the Space bar.
        /// </summary>
        public string ControlHintEscapeLabel
        {
            get => _controlHintEscapeLabel;
            private set => Set(ref _controlHintEscapeLabel, value);
        }

        /// <summary>
        /// Gets or sets the Pin window toggle button label.
        /// </summary>
        public string ToggleBtnPinWindowContent
        {
            get => _toggleBtnPinWindowContent;
            private set => Set(ref _toggleBtnPinWindowContent, value);
        }

        /// <summary>
        /// Gets or sets the Pin window toggle button label.
        /// </summary>
        public string ToggleBtnPinWindowTooltip
        {
            get => _toggleBtnPinWindowTooltip;
            private set => Set(ref _toggleBtnPinWindowTooltip, value);
        }

        /// <summary>
        /// Gets or sets the no layout available indicator.
        /// </summary>
        public bool NoLayoutAvailable
        {
            get => _noLayoutAvailable;
            private set => Set(ref _noLayoutAvailable, value);
        }

        /// <summary>
        /// Gets or sets the pinned status.
        /// </summary>
        public bool IsWindowPinned
        {
            get => _isWindowPinned;
            set => Set(ref _isWindowPinned, value);
        }

        /// <summary>
        /// Gets or sets the keyboard view.
        /// </summary>
        public object KeyboardView
        {
            get => _keyboardView;
            set => Set(ref _keyboardView, value);
        }

#endregion

#region Relay commands

        /// <summary>
        /// Lost focus command.
        /// </summary>
        public ICommand LostFocusCommand =>
            _lostFocusCommand
            ?? (_lostFocusCommand = new RelayCommand(LostFocus, LostFocusCanExecute));

        /// <summary>
        /// Hide window command.
        /// </summary>
        public ICommand HideWindowCommand =>
            _hideWindowCommand
            ?? (_hideWindowCommand = new RelayCommand(LostFocus));

        /// <summary>
        /// Next layer command.
        /// </summary>
        public ICommand NextLayerCommand =>
            _nextLayerCommand
            ?? (_nextLayerCommand = new RelayCommand(NextLayer));

        /// <summary>
        /// Next layer command.
        /// </summary>
        public ICommand ScrollLayerCommand =>
            _scrollLayerCommand
            ?? (_scrollLayerCommand = new RelayCommand<MouseWheelEventArgs>(ScrollLayer));

#endregion

        public DisplayLayoutViewModel(IWindowService windowService, ILayoutService layoutService, ISettingsService settingsService)
        {
            Logger.TraceConstructor();

            _windowService = windowService;
            _layoutService = layoutService;
            _settingsService = settingsService;

            Messenger.Default.Register<UpdatedLayoutMessage>(this, LoadCompleteLayout);

            // TODO : add the currentKeyboard selector
            //SetCurrentKeyboard();
            SetLabelUi();
            SetWindowParameters();
            LoadCompleteLayout();
        }

#region Delegates

        private void LoadCompleteLayout(UpdatedLayoutMessage obj)
        {
            Logger.TraceMethod("Intercept {0} message");
            LoadCompleteLayout();
        }

        private void LostFocus()
        {
            Logger.TraceRelayCommand();
            _windowService.CloseWindow<DisplayLayoutWindow>();
        }

        private void NextLayer()
        {
            Logger.TraceRelayCommand();

            SwitchLayer(SwitchDirection.Up);
        }

        private void ScrollLayer(MouseWheelEventArgs e)
        {
            Logger.TraceRelayCommand();

            SwitchDirection direction = SwitchDirection.Stay;

            if (e.Delta < 0) { direction = SwitchDirection.Up; }

            if (e.Delta > 0) { direction = SwitchDirection.Down; }

            SwitchLayer(direction);
        }

        private bool LostFocusCanExecute()
        {
            var canExecute = !IsWindowPinned;

            return canExecute;
        }

#endregion

#region Private methods

        private void SetLabelUi()
        {
            WindowTitle = "ErgoDox Layout";
            NoLayoutWarningFirstLine = "No layout available !";
            NoLayoutWarningSecondLine = "Please, go to the settings and update the layout.";
            CurrentLayerNameTitle = "Current layer :";
            CurrentLayerName = "";
            ControlHintSpaceLabel = "Scroll up/down or press 'Space' to display next layer";
            ControlHintEscapeLabel = "Press 'Escape' to hide window";
            ToggleBtnPinWindowContent = "_Pin window";
            ToggleBtnPinWindowTooltip = "Press 'P' to toggle";
        }

        private void SetWindowParameters()
        {
            IsWindowPinned = false;
        }

        private async void LoadCompleteLayout()
        {
            Logger.TraceMethod();

            if (IsInDesignModeStatic)
            {
                LoadDesignTimeModel();

                return;
            }

            var ezLayout = _settingsService.EZLayout;
            Logger.Debug("EZLayout = {@value0}", ezLayout);

            if (IsLayoutAvailable(ezLayout)) return;

            NoLayoutAvailable = false;
            await _keyboard.LoadLayoutAsync(ezLayout);

            /* TODO : Add DataTemplates to select correct view and DataTriggers in DisplayLayoutWindow
             *KeyboardView = _keyboard.GetKeyboardView();
             */
        }

        private bool IsLayoutAvailable(EZLayout ezLayout)
        {
            var isAvailable = false;

            if (ezLayout?.EZLayers == null
                || !ezLayout.EZLayers.Any()
                || !ezLayout.EZLayers.SelectMany(l => l.EZKeys).Any())
            {
                Logger.Info("No layout available");
                NoLayoutAvailable = true;

                isAvailable = true;
            }

            return isAvailable;
        }

        private void LoadDesignTimeModel() { }

        private void SwitchLayer(SwitchDirection direction)
        {
            Logger.TraceMethod();

            _keyboard.SwitchLayer(SwitchDirection.Up);
            CurrentLayerName = _keyboard.GetCurrentLayerName();
        }

#endregion
    }
}