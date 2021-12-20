namespace DevSkill.DevTrack.ClientTool.Models.ConfigurationObjects
{
    public class ElectronWindowOptions
    {
        public int ScreenOneWidth { get; set; }
        public int ScreenOneHeight { get; set; }
        public int ScreenTwoWidth { get; set; }
        public int ScreenTwoHeight { get; set; }
        public bool Show { get; set; }
        public bool AutoHideMenuBar { get; set; }
        public bool Frame { get; set; }
        public bool Transparent { get; set; }
        public bool Resizable { get; set; }
        public string Title { get; set; }
    }
}