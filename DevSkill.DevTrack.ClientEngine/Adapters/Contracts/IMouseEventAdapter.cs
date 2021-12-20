using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientEngine.Adapters.Contracts
{
    public interface IMouseEventAdapter
    {
        void Start();
        void Stop();
        MouseActivity GetMouseEventLogs();
        void ClearMouseEventLogs();
    }
}