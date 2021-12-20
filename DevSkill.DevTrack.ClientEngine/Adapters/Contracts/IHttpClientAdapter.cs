using System.Threading;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Adapters.Contracts
{
    public interface IHttpClientAdapter
    {
        Task<TR> GetAsync<T, TR>(T data, string url, CancellationToken cancellationToken, string token = null);
        Task<TR> PostAsync<T, TR>(T data, string url, CancellationToken cancellationToken, string token);
    }
}