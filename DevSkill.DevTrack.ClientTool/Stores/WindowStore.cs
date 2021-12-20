using DevSkill.DevTrack.ClientTool.Helpers;
using ElectronNET.API;

namespace DevSkill.DevTrack.ClientTool.Stores
{
    public class WindowStore : IWindowStore
    {
        public BrowserWindow MainWindow { get; set; }
        public BrowserWindow TrackerWindow { get; set; }
        public BrowserWindow CurrentWindow { get; set; }
    }
}