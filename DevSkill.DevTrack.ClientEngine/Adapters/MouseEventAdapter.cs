using System.Threading.Tasks;
using System.Windows.Forms;
using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;
using DevSkill.DevTrack.ClientEngine.BusinessObjects;
using Gma.System.MouseKeyHook;

namespace DevSkill.DevTrack.ClientEngine.Adapters
{
    public class MouseEventAdapter : IMouseEventAdapter
    {
        private IKeyboardMouseEvents _keyboardMouseEvents;
        private readonly MouseActivity _mouseActivity;

        public MouseEventAdapter()
        {
            _mouseActivity = new();
        }

        private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
        {
            _mouseActivity.TotalHits += 1;
        }
    
        public void Start()
        {
            ClearMouseEventLogs();
        
            Task.Run(() =>
            {
                _keyboardMouseEvents = Hook.GlobalEvents();
                _keyboardMouseEvents.MouseDownExt += GlobalHookMouseDownExt;
                Application.Run();
            });
        }
    
        public void Stop()
        {
            _keyboardMouseEvents.MouseDownExt -= GlobalHookMouseDownExt;
            _keyboardMouseEvents?.Dispose();
        }

        public MouseActivity GetMouseEventLogs()
        {
            return _mouseActivity;
        }

        public void ClearMouseEventLogs()
        {
            _mouseActivity.TotalHits = 0;
        }
    }
}