using System;
using System.Runtime.InteropServices;

namespace DevSkill.DevTrack.ClientEngine.Adapters.Win32API
{
    public static class Win32Native
    {
        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hDC, int index);
    }
}