using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Hooks;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.WindowsApi
{
    internal static class HookHelper
    {
        private static HookProcedure _globalHookProc;

        public static HookResult HookGlobalForegroundWindow(Callback callback)
        {
            return HookGlobal(HookIds.WH_FOREGROUND_WINDOW, callback);
        }

        private static HookResult HookGlobal(uint hookId, Callback callback)
        {
            _globalHookProc = (hWinEventHook, eventType, hWnd, idObject, idChild, eventThread, eventTime)
                => HookProcedure(hWinEventHook, eventType, hWnd, idObject, idChild, eventThread, eventTime, callback);

            var hookHandle = HookNativeMethods.SetWinEventHook(hookId, hookId,
                IntPtr.Zero, _globalHookProc, 0, 0, HookIds.WH_OUTOFCONTEXT | HookIds.WH_SKIPOWNPROCESS);

            if (hookHandle == IntPtr.Zero) ThrowLastUnmanagedErrorAsException();

            return new HookResult(hookHandle, _globalHookProc);
        }

        private static IntPtr HookProcedure(IntPtr hWinEventHook, uint eventType, IntPtr hWnd, int idObject, int idChild,
            uint eventThread, uint eventTime, Callback callback)
        {

            var callbackData = new CallbackData(hWnd);
            var continueProcessing = callback(callbackData);

            if (!continueProcessing)
                return new IntPtr(-1);

            return hWnd;
        }

        private static void ThrowLastUnmanagedErrorAsException()
        {
            var errorCode = Marshal.GetLastWin32Error();
            throw new Win32Exception(errorCode);
        }
    }
}