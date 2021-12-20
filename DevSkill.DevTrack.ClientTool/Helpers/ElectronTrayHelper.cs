using DevSkill.DevTrack.ClientTool.Stores;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientTool.Helpers
{
    public class ElectronTrayHelper : IElectronTrayHelper
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IElectronWindowHelper _electronWindowHelper;
        private readonly IWindowStore _windowStore;

        public ElectronTrayHelper(IWebHostEnvironment webHostEnvironment,
            IElectronWindowHelper electronWindowHelper, IWindowStore windowStore)
        {
            _webHostEnvironment = webHostEnvironment;
            _electronWindowHelper = electronWindowHelper;
            _windowStore = windowStore;
        }

        public async Task InitializeTrayAsync()
        {
            if (!HybridSupport.IsElectronActive)
            {
                return;
            }

            if (Electron.Tray.MenuItems.Count == 0)
            {
                var menu = new MenuItem
                {
                    Label = "Quit App",
                    Click = async () => await _electronWindowHelper.QuitApp()
                };
                Electron.Tray.SetToolTip("Click to Restore");
                Electron.Tray.Show(Path.Combine(_webHostEnvironment.WebRootPath, "assets/images/logo.jfif"), menu);
                Electron.Tray.OnClick += async (args, rectangle) => await SingleClickAsync();
            }
        }

        public async Task MinimizeToTrayAsync()
        {
            await Task.Run(() =>
            {
                _windowStore.CurrentWindow?.Hide();
                _windowStore.CurrentWindow?.SetSkipTaskbar(true);
            });
        }

        private async Task RestoreFromTrayAsync()
        {
            await Task.Run(() =>
            {
                _windowStore.CurrentWindow?.Show();
                _windowStore.CurrentWindow?.SetSkipTaskbar(false);
            });
        }

        private async Task SingleClickAsync()
        {
            if (await _windowStore.CurrentWindow.IsVisibleAsync())
            {
                await MinimizeToTrayAsync();
            }
            else
            {
                await RestoreFromTrayAsync();
            }
        }
    }
}