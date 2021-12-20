using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IActiveWindowService
    {
        Task AddActiveWindowLogsAsync(ActiveWindow activeWindow);
        Task StartEventAsync();
        Task StopEventAsync();
        Task<ActiveWindow> GetActiveWindowLogsAsync(Guid activityId);
    }
}