using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Events;
using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.WindowsApi;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Hooks
{
    internal class GlobalForegroundWindowListener : ForegroundWindowListener
    {
        public GlobalForegroundWindowListener()
            : base(HookHelper.HookGlobalForegroundWindow)
        {
        }

        protected override ForegroundWindowEventArgs GetForegroundWindowEventArgs(CallbackData data)
        {
            return ForegroundWindowEventArgs.FromRawDataGlobal(data);
        }
    }
}