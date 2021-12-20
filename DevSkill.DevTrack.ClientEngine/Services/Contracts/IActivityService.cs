using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IActivityService
    {
        Task<Activity> GetActivityAsync();
        Task AddActivityAsync(Activity activity);
    }
}