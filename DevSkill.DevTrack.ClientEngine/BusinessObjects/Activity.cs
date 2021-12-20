using System;
using System.Collections.Generic;

namespace DevSkill.DevTrack.ClientEngine.BusinessObjects
{
    public class Activity
    {
        public Guid ApplicationUserId { get; set; }
        public Guid ProjectId { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsOnline { get; set; } = true;
        public KeyboardActivity KeyboardActivity { get; set; }
        public MouseActivity MouseActivity { get; set; }
        public List<RunningProgram> RunningPrograms { get; set; }
        public List<ActiveWindow> ActiveWindows { get; set; }
        public ScreenCapture ScreenCapture { get; set; }
        public WebcamCapture WebcamCapture { get; set; }
    }
}