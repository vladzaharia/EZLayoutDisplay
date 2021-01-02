using System;

namespace InvvardDev.EZLayoutDisplay.Core.Services.Interface
{
    public interface IKeyboardHookService : IDisposable
    {
        void RegisterHotkey(ModifierKeys modifiers, int keyCode);
    }
}