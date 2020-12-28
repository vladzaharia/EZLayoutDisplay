using System.Collections.Generic;
using InvvardDev.EZLayoutDisplay.Keyboards.Zsa.ViewModel;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa
{
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