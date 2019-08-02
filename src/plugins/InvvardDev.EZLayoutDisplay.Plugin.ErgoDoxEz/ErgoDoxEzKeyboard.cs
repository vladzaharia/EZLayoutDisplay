using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.Service;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.View;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.ViewModel;
using InvvardDev.EZLayoutDisplay.PluginContract;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards
{
    [Export(typeof(IKeyboardContract))]
    public class ErgoDoxEzKeyboard : IKeyboardContract
    {
        private const string LayoutDefinitionPath = "/data/ergoDoxEzLayoutDefinition.json";
        private readonly ILayoutService _layoutService;
        private ErgoDoxEzViewModel _viewModel;

        public IEnumerable<string> SupportedKeyboardModel { get; }

        public ErgoDoxEzKeyboard()
        {
            _layoutService = new LayoutService();
            SupportedKeyboardModel = new List<string> {
                                                          "ergodox ez"
                                                      };
        }

        public async Task LoadLayoutAsync(EZLayout ezLayout)
        {
            var layoutDefinition = await _layoutService.LoadLayoutDefinitionAsync(LayoutDefinitionPath);
            var layoutTemplates = await _layoutService.PopulateLayoutTemplatesAsync(layoutDefinition, ezLayout);
            _viewModel = new ErgoDoxEzViewModel(layoutTemplates);
        }

        public string GetCurrentLayerName()
        {
            return "Not implemented yet";
        }

        public object GetKeyboardView()
        {
            return new ErgoDoxEzView {
                                         DataContext = _viewModel
                                     };
        }
    }
}