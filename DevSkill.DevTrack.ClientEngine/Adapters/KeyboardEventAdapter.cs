using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;
using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using Gma.System.MouseKeyHook;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevSkill.DevTrack.ClientEngine.Adapters
{
    public class KeyboardEventAdapter : IKeyboardEventAdapter
    {
        private IKeyboardMouseEvents _keyboardMouseEvents;
        private readonly KeyboardActivity _keyboardActivity;

        public KeyboardEventAdapter()
        {
            _keyboardActivity = new KeyboardActivity
            {
                KeyCounts = new Dictionary<string, int>(),
                TotalHits = 0
            };
        }

        private void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
        {
            string value = KeyValue(e.KeyChar);

            if (_keyboardActivity.KeyCounts.ContainsKey(value))
            {
                _keyboardActivity.KeyCounts[value] += 1;
            }
            else
            {
                _keyboardActivity.KeyCounts[value] = 1;
            }

            _keyboardActivity.TotalHits += 1;
        }

        public void Start()
        {
            ClearKeyboardEventLogs();

            Task.Run(() =>
            {
                _keyboardMouseEvents = Hook.GlobalEvents();
                _keyboardMouseEvents.KeyPress += GlobalHookKeyPress;
                Application.Run();
            });
        }

        public void Stop()
        {
            _keyboardMouseEvents.KeyPress -= GlobalHookKeyPress;
            _keyboardMouseEvents?.Dispose();
        }

        public KeyboardActivity GetKeyboardEventLogs()
        {
            return _keyboardActivity;
        }

        public void ClearKeyboardEventLogs()
        {
            _keyboardActivity.KeyCounts.Clear();
            _keyboardActivity.TotalHits = 0;
        }

        private static string KeyValue(char key) => (int)key switch
        {
            >= 33 and <= 126 => key.ToString(),
            _ => "Others"
        };
    }
}