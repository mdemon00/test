using DevSkill.DevTrack.ClientTool.Enums;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientTool.Helpers
{
    public interface IElectronWindowHelper
    {
        Task SwitchToWindow(WindowEnum desiredWindowEnum);
        Task QuitApp();
    }
}