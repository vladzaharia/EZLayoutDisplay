using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using InvvardDev.EZLayoutDisplay.Keyboards.Common;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Enum;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Model;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Service;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa.ViewModel
{
    public class ZsaKeyboardViewModel : ViewModelBase, IKeyboardContract
    {
#region Fields

        private readonly ITemplateService                        _layoutService;
        private          List<ObservableCollection<KeyTemplate>> _layoutTemplates;
        private          ObservableCollection<KeyTemplate>       _currentLayoutTemplate;
        protected        int                                     _currentLayerIndex;
        protected        int                                     _maxLayerIndex;
        protected        EZLayout                                _ezLayout;
        protected        string                                  _layoutDefinitionPath;

        public IEnumerable<string> SupportedKeyboardModel { get; protected set; }

#endregion

#region Properties

        /// <summary>
        /// Gets or sets the layout template.
        /// </summary>
        public ObservableCollection<KeyTemplate> CurrentLayoutTemplate
        {
            get => _currentLayoutTemplate;
            set => Set(ref _currentLayoutTemplate, value);
        }

#endregion

        public ZsaKeyboardViewModel(ITemplateService layoutService)
        {
            _layoutService = layoutService;
            _currentLayerIndex = 0;
        }

#region IKeyboardContract implementation

        /// <inheritdoc />
        public async Task LoadLayoutAsync(EZLayout ezLayout)
        {
            _ezLayout = ezLayout;

            var layoutDefinition = await _layoutService.LoadLayoutDefinitionAsync(_layoutDefinitionPath);
            _layoutTemplates = await _layoutService.PopulateLayoutTemplatesAsync(layoutDefinition.ToList(), _ezLayout);
            _maxLayerIndex = _layoutTemplates.Count() - 1;

            CurrentLayoutTemplate = _layoutTemplates[_currentLayerIndex];
        }

        /// <inheritdoc />
        public string GetCurrentLayerName()
        {
            return $"{_ezLayout.EZLayers[_currentLayerIndex].Name} {_ezLayout.EZLayers[_currentLayerIndex].Index}";
        }

        /// <inheritdoc />
        public void SwitchLayer(SwitchDirection direction)
        {
            VaryLayer(direction);

            CurrentLayoutTemplate = _layoutTemplates[_currentLayerIndex];
        }

#endregion

#region Private methods

        private void VaryLayer(SwitchDirection direction)
        {
            switch (_currentLayerIndex)
            {
                case var _ when _maxLayerIndex <= 0:
                    _currentLayerIndex = 0;

                    break;
                case var _ when _currentLayerIndex <= 0 && direction == SwitchDirection.Down:
                    _currentLayerIndex = _maxLayerIndex;

                    break;
                case var _ when _currentLayerIndex > 0 && direction == SwitchDirection.Down:
                    _currentLayerIndex--;

                    break;
                case var _ when _currentLayerIndex >= _maxLayerIndex && direction == SwitchDirection.Up:
                    _currentLayerIndex = 0;

                    break;
                case var _ when _currentLayerIndex < _maxLayerIndex && direction == SwitchDirection.Up:
                    _currentLayerIndex++;

                    break;
            }
        }

#endregion
    }
}