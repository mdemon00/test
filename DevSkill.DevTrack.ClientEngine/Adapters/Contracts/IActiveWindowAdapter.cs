using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System.Collections.Generic;

namespace DevSkill.DevTrack.ClientEngine.Adapters.Contracts
{
    public interface IActiveWindowAdapter
    {
        void Start();
        void Stop();
        IList<ActiveWindow> GetActiveWindowEventLogs();
        void ClearActiveWindowEventLogs();
    }
}