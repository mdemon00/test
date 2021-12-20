using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Events;
using DevSkill.DevTrack.ClientEngine.Adapters.ActiveWindowEventHook.Hooks;
using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;
using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevSkill.DevTrack.ClientEngine.Adapters
{
    public class ActiveWindowAdapter : IActiveWindowAdapter
    {
        private IHookEvents _hookEvents;
        private IDateTimeAdapter _dateTimeAdapter;
        private IList<ActiveWindow> _activeWindows;

        public ActiveWindowAdapter()
        {
            _dateTimeAdapter = new DateTimeAdapter();
            _activeWindows = new List<ActiveWindow>();
        }

        public ActiveWindowAdapter(IDateTimeAdapter dateTimeAdapter)
        {
            _dateTimeAdapter = dateTimeAdapter;
            _activeWindows = new List<ActiveWindow>();
        }

        public void Start()
        {
            Task.Run(() =>
            {
                _hookEvents = Hook.GlobalEvents();
                _hookEvents.ForegroundWindow += HookEventsOnForegroundWindow;
                Application.Run();
            });
        }

        public void Stop()
        {
            _hookEvents.ForegroundWindow -= HookEventsOnForegroundWindow;
            _hookEvents?.Dispose();
        }

        public IList<ActiveWindow> GetActiveWindowEventLogs()
        {
            return _activeWindows;
        }

        public void ClearActiveWindowEventLogs()
        {
            _activeWindows.Clear();
        }

        private void HookEventsOnForegroundWindow(object sender, ForegroundWindowEventArgs e)
        {
            var activeWindow = new ActiveWindow
            {
                ProcessName = e.ProcessName,
                WindowTitle = e.WindowTitle,
                Time = _dateTimeAdapter.UtcNow
            };

            _activeWindows.Add(activeWindow);
        }
    }
}