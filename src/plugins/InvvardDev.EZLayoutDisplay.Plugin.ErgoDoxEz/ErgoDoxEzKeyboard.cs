using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using InvvardDev.EZLayoutDisplay.Plugin.CommonZsa.Service;
using InvvardDev.EZLayoutDisplay.Plugin.ErgoDoxEz.View;
using InvvardDev.EZLayoutDisplay.Plugin.ErgoDoxEz.ViewModel;
using InvvardDev.EZLayoutDisplay.PluginContract;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.ErgoDoxEz
{
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