using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IRunningProgramsService
    {
        Task AddRunningProgramsAsync(RunningProgram runningProgram);
        Task<RunningProgram> GetRunningProgramsAsync(Guid activityId);
    }
}