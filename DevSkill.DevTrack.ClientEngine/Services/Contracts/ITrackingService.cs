using System.Threading;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Services.Contracts
{
    public interface ITrackingService
    {
        Task StartTracking(CancellationToken cancellationToken);
        void StopTracking();
    }
}