using System.Collections.Generic;
using System.ComponentModel.Composition;
using InvvardDev.EZLayoutDisplay.Keyboards.Common;
using InvvardDev.EZLayoutDisplay.Keyboards.Zsa.ViewModel;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa
{
    [ Export(typeof(IKeyboardContract)) ]
    public sealed class PlanckEzKeyboard : ZsaKeyboardBase
    {
        public PlanckEzKeyboard()
        {
            LayoutDefinitionPath = "/data/planckEzLayoutDefinition.json";
            SupportedKeyboardModel = new List<string> {
                                                          "planck ez"
                                                      };
        }

        public override object GetKeyboardView()
        {
            ViewModel = new PlanckEzViewModel();

            return KeyboardView;
        }
    }
}