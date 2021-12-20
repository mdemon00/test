using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface IAuthService
    {
        Task LoginAsync(string userName, string password);
        Task LogoutAsync();
    }
}