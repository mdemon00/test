using System;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.WindowsApi
{
    internal struct CallbackData
    {
        public CallbackData(IntPtr hWnd)
        {
            Hwnd = hWnd;
        }
        public IntPtr Hwnd { get; }
    }
}