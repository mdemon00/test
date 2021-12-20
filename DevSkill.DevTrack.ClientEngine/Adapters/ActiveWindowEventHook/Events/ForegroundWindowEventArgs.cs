using System;
using System.Diagnostics;
using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.WindowsApi;

namespace DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Events
{
    public class ForegroundWindowEventArgs : EventArgs
    {
        public ForegroundWindowEventArgs(string processName, string windowTitle, int timeStamp)
        {
            ProcessName = processName;
            WindowTitle = windowTitle;
            TimeStamp = timeStamp;
        }

        public bool Handled { get; set; }
        public string ProcessName { get; set; }
        public string WindowTitle { get; set; }
        public int TimeStamp { get; set; }

        internal static ForegroundWindowEventArgs FromRawDataGlobal(CallbackData data)
        {
            var hWnd = data.Hwnd;

            ThreadNativeMethods.GetWindowThreadProcessId(hWnd, out uint processId);

            Process process = Process.GetProcessById((int)processId);

            int timestamp = Environment.TickCount;

            return new ForegroundWindowEventArgs(process.ProcessName, process.MainWindowTitle, timestamp);
        }
    }
}