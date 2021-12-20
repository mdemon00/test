using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IMouseActivityService
    {
        Task AddMouseActivityAsync(MouseActivity mouseActivity);
        Task GetMouseActivityAsync(Guid activityId);
    }
}