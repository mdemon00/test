using System;
using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.WindowsApi;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Hooks
{
    internal abstract class BaseListener : IDisposable
    {
        protected BaseListener(Subscribe subscribe)
        {
            Handle = subscribe(Callback);
        }

        protected HookResult Handle { get; set; }

        public void Dispose()
        {
            Handle.Dispose();
        }

        protected abstract bool Callback(CallbackData data);
    }
}