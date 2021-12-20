using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IKeyboardActivityService
    {
        Task AddKeyboardActivityLogsAsync(KeyboardActivity keyboardActivity);
        Task StartEventAsync();
        Task StopEventAsync();
        Task<KeyboardActivity> GetKeyboardActivityLogsAsync(Guid activityId);
    }
}