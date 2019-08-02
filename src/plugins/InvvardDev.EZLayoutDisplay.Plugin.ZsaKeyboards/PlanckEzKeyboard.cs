using System.Collections.Generic;
using System.ComponentModel.Composition;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.ViewModel;
using InvvardDev.EZLayoutDisplay.PluginContract;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards
{
    [Export(typeof(IKeyboardContract))]
    public class PlanckEzKeyboard : ZsaKeyboardBase
    {
        public PlanckEzKeyboard()
        {
            LayoutDefinitionPath = "/data/planckEzLayoutDefinition.json";
            SupportedKeyboardModel = new List<string> {
                                                          "planck ez"
                                                      };
        }
        protected override void CreateViewModel(IEnumerable<IEnumerable<KeyTemplate>> layoutTemplates)
        {
            _viewModel = new PlanckEzViewModel(layoutTemplates);
        }

        public override object GetKeyboardView()
        {
            throw new System.NotImplementedException();
        }
    }
}