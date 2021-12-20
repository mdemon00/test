using DevSkill.DevTrack.ClientEngine.BusinessObjects;

namespace DevSkill.DevTrack.ClientEngine.Adapters.Contracts
{
    public interface IKeyboardEventAdapter
    {
        void Start();
        void Stop();
        KeyboardActivity GetKeyboardEventLogs();
        void ClearKeyboardEventLogs();
    }
}