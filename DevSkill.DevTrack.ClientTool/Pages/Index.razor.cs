using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientTool.Pages
{
    public partial class Index
    {
        private readonly Models.Account.LoginModel _model = new();

        public async Task OnValidSubmitAsync()
        {
            await _electronWindowHelper.SwitchToWindow(Enums.WindowEnum.TrackerWindow);
        }

        public async Task ExitAppAsync()
        {
            await _electronWindowHelper.QuitApp();
        }
    }
}