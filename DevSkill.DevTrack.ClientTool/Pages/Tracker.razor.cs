using DevSkill.DevTrack.ClientTool.Models.Tracker;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace DevSkill.DevTrack.ClientTool.Pages
{
    public partial class Tracker
    {
        private bool _isTrackerOn;
        private Timer _timer;
        private int _secondsTracked;
        private ProjectModel _activeProject;
        private List<ProjectModel> ProjectModels { get; set; }

        public void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (_isTrackerOn)
            {
                InvokeAsync(() =>
                {
                    _secondsTracked += 1;
                    StateHasChanged();
                });
            }
        }

        public async Task ToggleTrackingAsync()
        {
            _isTrackerOn = !_isTrackerOn;
        }

        public async Task OnChangeAsync(ChangeEventArgs e)
        {
            _activeProject = await Task.FromResult(ProjectModels
                .FirstOrDefault(x => x.Id == int.Parse(e.Value?.ToString() ?? "-1")));
        }

        public async Task OnMinimizeButtonClickAsync()
        {
            await _electronTrayHelper.MinimizeToTrayAsync();
        }

        public async Task OnExitButtonClickAsync()
        {
            await _electronWindowHelper.SwitchToWindow(Enums.WindowEnum.MainWindow);
        }

        public void Dispose() => _timer?.Dispose();

        protected override Task OnInitializedAsync()
        {
            ProjectModels = Enumerable.Range(1, 6)
                .Select(x => new ProjectModel { Id = x, Name = $"Fake Project {x}" })
                .ToList();

            _secondsTracked = 0;
            _isTrackerOn = false;
            _timer = new Timer { Interval = 1000 };
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
            return base.OnInitializedAsync();
        }

        protected override async Task<Task> OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await _electronTrayHelper.InitializeTrayAsync();
            }

            return base.OnAfterRenderAsync(firstRender);
        }
    }
}