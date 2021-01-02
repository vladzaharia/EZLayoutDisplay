using System.Diagnostics;
using InvvardDev.EZLayoutDisplay.Core.Services.Interface;

namespace InvvardDev.EZLayoutDisplay.Core.Services.Design
{
    public class KeyboardHookService : IKeyboardHookService
    {
        public void RegisterHotkey(ModifierKeys modifiers, int keyCode)
        {
            Debug.WriteLine("Hotkey registered");
        }

        public void Dispose()
        {
            Dispose(true);
        }

        // ReSharper disable once UnusedParameter.Global : DesignTime service implementation
        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine("Disposing the Design.KeyboardHookService");
        }
    }
}