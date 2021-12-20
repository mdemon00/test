using System;
using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Events;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Hooks
{
    internal abstract class EventFacade : IHookEvents
    {
        private ForegroundWindowListener m_ForegroundWindowListenerCache;


        public event EventHandler<ForegroundWindowEventArgs> ForegroundWindow
        {
            add { GetForegroundWindowListener().ForegroundWindow += value; }
            remove { GetForegroundWindowListener().ForegroundWindow -= value; }
        }

        private ForegroundWindowListener GetForegroundWindowListener()
        {
            var target = m_ForegroundWindowListenerCache;
            if (target != null) return target;
            target = CreateForegroundWindowListener();
            m_ForegroundWindowListenerCache = target;
            return target;
        }

        protected abstract ForegroundWindowListener CreateForegroundWindowListener();

        public void Dispose()
        {
            m_ForegroundWindowListenerCache?.Dispose();
        }
    }
}