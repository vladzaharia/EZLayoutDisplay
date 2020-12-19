using System.Collections.Generic;
using System.ComponentModel.Composition;
using InvvardDev.EZLayoutDisplay.Keyboards.Common;
using InvvardDev.EZLayoutDisplay.Keyboards.Zsa.View;
using InvvardDev.EZLayoutDisplay.Keyboards.Zsa.ViewModel;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa
{
    [ Export(typeof(IKeyboardContract)) ]
    public sealed class ErgoDoxEzKeyboard : ZsaKeyboardBase
    {
        public ErgoDoxEzKeyboard()
        {
            LayoutDefinitionPath = "\\data\\ergoDoxEzLayoutDefinition.json";
            SupportedKeyboardModel = new List<string> {
                                                          "ergodox ez",
                                                          "ergodox"
                                                      };
            ViewModel = new ErgoDoxEzViewModel();
        }

        public override object GetKeyboardView()
        {
            if (KeyboardView == null)
            {
                KeyboardView = new ErgoDoxEzView {
                                                     DataContext = ViewModel
                                                 };
            }

            return KeyboardView;
        }
    }
}