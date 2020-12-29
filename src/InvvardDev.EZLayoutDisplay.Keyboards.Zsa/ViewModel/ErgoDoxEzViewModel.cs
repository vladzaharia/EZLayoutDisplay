using System.Collections.Generic;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Service;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa.ViewModel
{
    internal class ErgoDoxEzViewModel : ZsaKeyboardViewModel
    {
        internal ErgoDoxEzViewModel(ILayoutService layoutService) : base(layoutService)
        {
            _layoutDefinitionPath = "\\data\\ergoDoxEzLayoutDefinition.json";
            SupportedKeyboardModel = new List<string> {
                                                          "ergodox ez",
                                                          "ergodox"
                                                      };
        }
    }
}