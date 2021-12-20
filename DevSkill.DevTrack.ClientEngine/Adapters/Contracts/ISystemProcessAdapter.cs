using System.Collections.Generic;
using System.Diagnostics;

namespace DevSkill.DevTrack.ClientEngine.Adapters.Contracts
{
    public interface ISystemProcessAdapter
    {
        IList<Process> GetRunningProcesses();
    }
}