using System.Collections.Generic;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Service;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa.ViewModel
{
    public class PlanckEzViewModel : ZsaKeyboardViewModel
    {
        public PlanckEzViewModel(ILayoutService layoutService) : base(layoutService)
        {
            _layoutDefinitionPath = "\\data\\planckEzLayoutDefinition.json";
            SupportedKeyboardModel = new List<string> {
                                                          "planck ez"
                                                      };
        }
    }
}