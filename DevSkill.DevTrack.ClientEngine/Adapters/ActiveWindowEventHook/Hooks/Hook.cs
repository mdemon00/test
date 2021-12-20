namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Hooks
{
    public static class Hook
    {
        public static IHookEvents GlobalEvents()
        {
            return new GlobalEventFacade();
        }
    }
}