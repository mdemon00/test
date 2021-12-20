using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;
using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System.Collections.Generic;

namespace DevSkill.DevTrack.ClientEngine.Adapters
{
    public class RunningProgramAdapter : IRunningProgramAdapter
    {
        private readonly ISystemProcessAdapter _systemProcessAdapter;
        private readonly IDateTimeAdapter _dateTimeAdapter;

        public RunningProgramAdapter(ISystemProcessAdapter systemProcessAdapter, IDateTimeAdapter dateTimeAdapter)
        {
            _systemProcessAdapter = systemProcessAdapter;
            _dateTimeAdapter = dateTimeAdapter;
        }

        public RunningProgram GetRunningPrograms()
        {
            var processes = _systemProcessAdapter.GetRunningProcesses();

            var runningProgram = new RunningProgram
            {
                RunningProcesses = new List<string>(),
                Time = _dateTimeAdapter.UtcNow
            };

            foreach (var process in processes)
            {
                if (!string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    runningProgram.RunningProcesses.Add(process.MainWindowTitle);
                }
            }

            return runningProgram;
        }
    }
}
