using System;
using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Events;
using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.WindowsApi;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Hooks
{
    internal abstract class ForegroundWindowListener : BaseListener, IForegroundWindowEvent
    {
        protected ForegroundWindowListener(Subscribe subscribe) : base(subscribe)
        {
        }

        public event EventHandler<ForegroundWindowEventArgs> ForegroundWindow;

        public void InvokeActiveWindow(ForegroundWindowEventArgs e)
        {
            var handler = ForegroundWindow;
            if (handler == null || e.Handled)
                return;
            handler(this, e);
        }

        protected override bool Callback(CallbackData data)
        {
            var eDownUp = GetForegroundWindowEventArgs(data);

            InvokeActiveWindow(eDownUp);

            return !eDownUp.Handled;
        }

        protected abstract ForegroundWindowEventArgs GetForegroundWindowEventArgs(CallbackData data);
    }
}