using System;
using System.Runtime.InteropServices;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.WindowsApi
{
    internal static class HookNativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        internal static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr winEventProc,
            HookProcedure winEventDelegate, uint idProcess,
            uint idThread, uint flags);

        [DllImport("user32.dll")]
        internal static extern bool UnhookWinEvent(IntPtr eventHook);
    }
}