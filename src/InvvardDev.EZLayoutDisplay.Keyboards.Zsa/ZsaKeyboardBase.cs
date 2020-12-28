using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using InvvardDev.EZLayoutDisplay.Keyboards.Common;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Enum;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Model;
using InvvardDev.EZLayoutDisplay.Keyboards.Zsa.Service;
using InvvardDev.EZLayoutDisplay.Keyboards.Zsa.ViewModel;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa
{
    public abstract class ZsaKeyboardBase : IKeyboardContract
    {
        private readonly ILayoutService _layoutService;
        private List<ObservableCollection<KeyTemplate>> _layoutTemplates;
        private int _currentLayerIndex;
        private int _maxLayerIndex;
        private EZLayout _ezLayout;

        protected UserControl KeyboardView;
        protected string LayoutDefinitionPath;
        protected ZsaKeyboardViewModel ViewModel;

        public IEnumerable<string> SupportedKeyboardModel { get; protected set; }

        protected ZsaKeyboardBase()
        {
            _layoutService = new LayoutService();
            _currentLayerIndex = 0;
        }

        #region IKeyboardContract implementation

        /// <inheritdoc />
        public string GetCurrentLayerName()
        {
            return $"{_ezLayout.EZLayers[_currentLayerIndex].Name} {_ezLayout.EZLayers[_currentLayerIndex].Index}";
        }

        /// <inheritdoc />
        public async Task LoadLayoutAsync(EZLayout ezLayout)
        {
            _ezLayout = ezLayout;

            var layoutDefinition = await _layoutService.LoadLayoutDefinitionAsync(LayoutDefinitionPath);
            _layoutTemplates = await _layoutService.PopulateLayoutTemplatesAsync(layoutDefinition.ToList(), _ezLayout);
            _maxLayerIndex = _layoutTemplates.Count() - 1;

            SwitchLayer();
        }

        /// <inheritdoc />
        public void SwitchLayer(SwitchDirection direction)
        {
            VaryLayer(direction);
        }

        /// <inheritdoc />
        public abstract object GetKeyboardView();

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

            SwitchLayer();
        }

        private void SwitchLayer()
        {
            ViewModel.CurrentLayoutTemplate = _layoutTemplates[_currentLayerIndex];
        }

        #endregion
    }
}