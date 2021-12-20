namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Hooks
{
    internal class GlobalEventFacade : EventFacade
    {
        protected override ForegroundWindowListener CreateForegroundWindowListener()
        {
            return new GlobalForegroundWindowListener();
        }
    }
}