using System;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.WindowsApi
{
    internal class HookResult : IDisposable
    {
        public HookResult(IntPtr handle, HookProcedure procedure)
        {
            Handle = new HookProcedureHandle(handle);
            Procedure = procedure;
        }

        public HookProcedureHandle Handle { get; }

        public HookProcedure Procedure { get; }

        public void Dispose()
        {
            Handle.Dispose();
        }
    }
}