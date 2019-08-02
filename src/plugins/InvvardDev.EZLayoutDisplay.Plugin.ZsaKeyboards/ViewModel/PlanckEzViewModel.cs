using System.Collections.Generic;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.ViewModel
{
    public class PlanckEzViewModel : ZsaKeyboardViewModelBase
    {
        internal PlanckEzViewModel(IEnumerable<IEnumerable<KeyTemplate>> layoutTemplates) : base(layoutTemplates) { }
    }
}