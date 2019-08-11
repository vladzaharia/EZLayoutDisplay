using System.Collections.Generic;
using System.ComponentModel.Composition;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.View;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.ViewModel;
using InvvardDev.EZLayoutDisplay.PluginContract;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards
{
    [Export(typeof(IKeyboardContract))]
    public class ErgoDoxEzKeyboard : ZsaKeyboardBase
    {
        public ErgoDoxEzKeyboard()
        {
            LayoutDefinitionPath = "/data/ergoDoxEzLayoutDefinition.json";
            SupportedKeyboardModel = new List<string> {
                                                          "ergodox ez"
                                                      };
        }

        /// <inheritdoc />
        protected override void CreateViewModel(IEnumerable<IEnumerable<KeyTemplate>> layoutTemplates)
        {
            _viewModel = new ErgoDoxEzViewModel(layoutTemplates);
        }

        public override object GetKeyboardView()
        {
            return new ErgoDoxEzView {
                                         DataContext = _viewModel
                                     };
        }
    }
}