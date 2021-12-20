using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IApplicationUserService
    {
        Task AddUserAsync(ApplicationUser applicationUser);
        Task<ApplicationUser> GetUserAsync();
    }
}