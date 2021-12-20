using System;
using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Events;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Hooks
{
    public interface IHookEvents : IForegroundWindowEvent, IDisposable
    {
    }
}