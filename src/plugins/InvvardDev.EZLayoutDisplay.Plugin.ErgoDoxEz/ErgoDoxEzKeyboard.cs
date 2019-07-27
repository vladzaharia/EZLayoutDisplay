using System.Collections.Generic;
using InvvardDev.EZLayoutDisplay.PluginContract;

namespace InvvardDev.EZLayoutDisplay.Plugin.ErgoDoxEz
{
    public class ErgoDoxEzKeyboard : IKeyboardContract
    {
        public IEnumerable<string> SupportedKeyboardModel { get; }

        public ErgoDoxEzKeyboard()
        {
            SupportedKeyboardModel = new List<string> {
                                                          "ergodox ez"
                                                      };
        }

        public string GetCurrentLayerName()
        {
            return "Not implemented yet";
        }
    }
}