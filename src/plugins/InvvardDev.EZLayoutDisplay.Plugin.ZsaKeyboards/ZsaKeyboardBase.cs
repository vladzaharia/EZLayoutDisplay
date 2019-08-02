using System.Collections.Generic;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.Service;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.ViewModel;
using InvvardDev.EZLayoutDisplay.PluginContract;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards
{
    public abstract class ZsaKeyboardBase : IKeyboardContract
    {
        protected string LayoutDefinitionPath;
        protected readonly ILayoutService _layoutService;
        protected ZsaKeyboardViewModelBase _viewModel;

        public IEnumerable<string> SupportedKeyboardModel { get; protected set; }

        protected ZsaKeyboardBase()
        {
            _layoutService = new LayoutService();
        }

        public string GetCurrentLayerName()
        {
            throw new System.NotImplementedException();
        }

        public async Task LoadLayoutAsync(EZLayout ezLayout)
        {
            var layoutDefinition = await _layoutService.LoadLayoutDefinitionAsync(LayoutDefinitionPath);
            var layoutTemplates = await _layoutService.PopulateLayoutTemplatesAsync(layoutDefinition, ezLayout);

            CreateViewModel(layoutTemplates);
        }

        protected abstract void CreateViewModel(IEnumerable<IEnumerable<KeyTemplate>> layoutTemplates);

        public abstract object GetKeyboardView();

    }
}