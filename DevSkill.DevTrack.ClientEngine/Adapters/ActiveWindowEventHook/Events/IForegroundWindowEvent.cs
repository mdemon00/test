using System;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Events
{
    public interface IForegroundWindowEvent
    {
        event EventHandler<ForegroundWindowEventArgs> ForegroundWindow;
    }
}