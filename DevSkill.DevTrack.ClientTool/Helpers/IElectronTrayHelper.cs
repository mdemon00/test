using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientTool.Helpers
{
    public interface IElectronTrayHelper
    {
        Task InitializeTrayAsync();
        Task MinimizeToTrayAsync();
    }
}