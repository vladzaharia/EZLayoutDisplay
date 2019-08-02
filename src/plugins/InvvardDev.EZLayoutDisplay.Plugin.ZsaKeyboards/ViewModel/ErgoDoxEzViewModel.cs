using System.Collections.Generic;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.ViewModel
{
    internal class ErgoDoxEzViewModel : ZsaKeyboardViewModelBase
    {
        internal ErgoDoxEzViewModel(IEnumerable<IEnumerable<KeyTemplate>> layoutTemplates) : base(layoutTemplates)
        {
        }
    }
}