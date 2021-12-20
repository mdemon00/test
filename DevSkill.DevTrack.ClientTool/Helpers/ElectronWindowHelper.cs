using DevSkill.DevTrack.ClientTool.Enums;
using DevSkill.DevTrack.ClientTool.Models.ConfigurationObjects;
using DevSkill.DevTrack.ClientTool.Stores;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DevSkill.DevTrack.ClientTool.Helpers
{
    public class ElectronWindowHelper : IElectronWindowHelper
    {
        private readonly IWindowStore _windowStore;
        private readonly ElectronWindowOptions _electronWindowOptions;

        public ElectronWindowHelper(IOptions<ElectronWindowOptions> electronWindowOptions, IWindowStore windowStore)
        {
            _windowStore = windowStore;
            _electronWindowOptions = electronWindowOptions.Value;
        }

        public async Task SwitchToWindow(WindowEnum desiredWindowEnum)
        {
            if (!HybridSupport.IsElectronActive)
            {
                return;
            }

            if (desiredWindowEnum == WindowEnum.MainWindow)
            {
                if (_windowStore.MainWindow == null)
                {
                    await InitializeWindowAsync(desiredWindowEnum);
                }
                else
                {
                    await ReactivateWindow(_windowStore.MainWindow);
                }

                await DeactivateWindow(_windowStore.TrackerWindow);
                _windowStore.CurrentWindow = _windowStore.MainWindow;
            }
            else
            {
                if (_windowStore.TrackerWindow == null)
                {
                    await InitializeWindowAsync(desiredWindowEnum);
                }
                else
                {
                    await ReactivateWindow(_windowStore.TrackerWindow);
                }

                await DeactivateWindow(_windowStore.MainWindow);
                _windowStore.CurrentWindow = _windowStore.TrackerWindow;
            }
        }

        public async Task QuitApp()
        {
            if (HybridSupport.IsElectronActive)
            {
                await Task.Run(() => Electron.App.Quit());
            }
        }

        private async Task ReactivateWindow(BrowserWindow window)
        {
            if (window == null)
            {
                return;
            }

            await window.WebContents.Session.ClearCacheAsync();
            window.Show();
        }

        private async Task DeactivateWindow(BrowserWindow window)
        {
            if (window == null)
            {
                return;
            }

            window.Hide();
            await window.WebContents.Session.ClearCacheAsync();
            window.Reload();
        }

        private async Task InitializeWindowAsync(WindowEnum desiredWindow)
        {
            int width, height;
            string url = null;

            if (desiredWindow == WindowEnum.MainWindow)
            {
                width = _electronWindowOptions.ScreenOneWidth;
                height = _electronWindowOptions.ScreenOneHeight;
                url = $"http://localhost:{BridgeSettings.WebPort}/";
            }
            else
            {
                width = _electronWindowOptions.ScreenTwoWidth;
                height = _electronWindowOptions.ScreenTwoHeight;
                url = $"http://localhost:{BridgeSettings.WebPort}/tracker";
            }

            var browserWindow = await Electron.WindowManager.CreateWindowAsync
            (
                new BrowserWindowOptions
                {
                    Width = width,
                    Height = height,
                    Show = _electronWindowOptions.Show,
                    AutoHideMenuBar = _electronWindowOptions.AutoHideMenuBar,
                    Frame = _electronWindowOptions.Frame,
                    Transparent = _electronWindowOptions.Transparent,
                    Resizable = _electronWindowOptions.Resizable
                },
                url
            );

            if (desiredWindow == WindowEnum.MainWindow)
            {
                _windowStore.MainWindow = browserWindow;
            }
            else
            {
                _windowStore.TrackerWindow = browserWindow;
            }

            await browserWindow.WebContents.Session.ClearCacheAsync();
            browserWindow.OnReadyToShow += async () => await SwitchToWindow(desiredWindow);
            browserWindow.SetTitle(_electronWindowOptions.Title);
        }
    }
}