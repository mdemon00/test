using System;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.WindowsApi
{
    internal class HookProcedureHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private static bool _closing;

        public HookProcedureHandle(IntPtr hWnd) : base(true)
        {
            handle = hWnd;
            Application.ApplicationExit += (sender, e) => { _closing = true; };
        }

        public HookProcedureHandle()
            : base(true)
        {
        }

        protected override bool ReleaseHandle()
        {
            if (_closing) return true;
            return HookNativeMethods.UnhookWinEvent(handle) != false;
        }
    }
}