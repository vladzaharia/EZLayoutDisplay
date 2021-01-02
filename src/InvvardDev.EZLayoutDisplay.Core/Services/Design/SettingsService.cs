using System.Diagnostics;
using InvvardDev.EZLayoutDisplay.Core.Models;
using InvvardDev.EZLayoutDisplay.Core.Services.Interface;
using NonInvasiveKeyboardHookLibrary;

namespace InvvardDev.EZLayoutDisplay.Core.Services.Design
{
    public class SettingsService : ISettingsService
    {
        public Hotkey HotkeyShowLayout { get; set; }
        public string ErgodoxLayoutUrl { get; set; }
        public EZLayout EZLayout { get; set; }

        public SettingsService()
        {
            HotkeyShowLayout = new Hotkey(0x60, ModifierKeys.Alt);
            ErgodoxLayoutUrl = "https://configure.ergodox-ez.com/layouts/default/latest/0";
        }

        public void Save()
        {
            Debug.WriteLine("Settings saved.");
        }

        public void Cancel()
        {
            Debug.WriteLine("Settings canceled.");
        }
    }
}