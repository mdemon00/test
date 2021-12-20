using ElectronNET.API;

namespace DevSkill.DevTrack.ClientTool.Stores
{
    public interface IWindowStore
    {
        BrowserWindow MainWindow { get; set; }
        BrowserWindow TrackerWindow { get; set; }
        BrowserWindow CurrentWindow { get; set; }
    }
}