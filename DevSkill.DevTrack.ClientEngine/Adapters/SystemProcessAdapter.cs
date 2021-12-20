using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;
using System.Collections.Generic;
using System.Diagnostics;

namespace DevSkill.DevTrack.ClientEngine.Adapters
{
    public class SystemProcessAdapter : ISystemProcessAdapter
    {
        public IList<Process> GetRunningProcesses()
        {
            return Process.GetProcesses();
        }
    }
}
