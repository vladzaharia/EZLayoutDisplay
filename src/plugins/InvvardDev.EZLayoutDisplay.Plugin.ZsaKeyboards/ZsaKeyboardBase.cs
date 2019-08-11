using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.Service;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.ViewModel;
using InvvardDev.EZLayoutDisplay.PluginContract;
using InvvardDev.EZLayoutDisplay.PluginContract.Enum;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards
{
    public abstract class ZsaKeyboardBase : IKeyboardContract
    {
        protected string LayoutDefinitionPath;
        private readonly ILayoutService _layoutService;
        protected ZsaKeyboardViewModelBase _viewModel;

        public IEnumerable<string> SupportedKeyboardModel { get; protected set; }

        protected ZsaKeyboardBase()
        {
            _layoutService = new LayoutService();
        }

        #region IKeyboardContract implementation

        /// <inheritdoc />
        public string GetCurrentLayerName()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public async Task LoadLayoutAsync(EZLayout ezLayout)
        {
            var layoutDefinition = await _layoutService.LoadLayoutDefinitionAsync(LayoutDefinitionPath);
            var layoutTemplates = await _layoutService.PopulateLayoutTemplatesAsync(layoutDefinition.ToList(), ezLayout);

            CreateViewModel(layoutTemplates);
        }

        /// <inheritdoc />
        public void SwitchLayer(SwitchDirection direction)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public abstract object GetKeyboardView();

        #endregion

        #region Private methods
        
        /// <summary>
        /// Creates the view model to be used alongside the view.
        /// </summary>
        /// <param name="layoutTemplates">The <see cref="List{KeyTemplate}"/> to be displayed.</param>
        protected abstract void CreateViewModel(IEnumerable<IEnumerable<KeyTemplate>> layoutTemplates);
        
        #endregion
    }
}