using System;

namespace DevSkill.DevTrack.ClientEngine.BusinessObjects
{
    public class Project
    {
        public Guid Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public string Title { get; set; }
        public bool AllowScreenshot { get; set; }
        public bool AllowMouse { get; set; }
        public bool AllowWebcam { get; set; }
        public bool AllowKeyboard { get; set; }
        public int TimeInterval { get; set; }
    }
}