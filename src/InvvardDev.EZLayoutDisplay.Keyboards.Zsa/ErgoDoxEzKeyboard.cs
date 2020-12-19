using System.Collections.Generic;
using System.ComponentModel.Composition;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.View;
using InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.ViewModel;
using InvvardDev.EZLayoutDisplay.PluginContract;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards
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