using System;
using System.Drawing;
using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;
using DevSkill.DevTrack.ClientEngine.Adapters.Win32API;

namespace DevSkill.DevTrack.ClientEngine.Adapters
{
    public class ScreenSizeAdapter : IScreenSizeAdapter
    {
        public (int width, int height) GetScreenSize()
        {
            const int desktopVertres = 0x75;
            const int desktopHorzres = 0x76;

            int width, height;
            using (var g = Graphics.FromHwnd(IntPtr.Zero))
            {
                var hDC = g.GetHdc();
                width = Win32Native.GetDeviceCaps(hDC, desktopHorzres);
                height = Win32Native.GetDeviceCaps(hDC, desktopVertres);
                g.ReleaseHdc(hDC);
            }

            return (width, height);
        }
    }
}
