using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Imaging;

namespace MigrationRunnerExtension
{
    [Guid("b2c42c50-d7bd-4724-9647-7f7e36165010")]
    public class MigrationRunnerToolWindow : ToolWindowPane
    {
        public MigrationRunnerToolWindow() : base(null)
        {
            this.Caption = "MigrationRunnerToolWindow";
            this.BitmapImageMoniker = KnownMonikers.UpdateDatabase;
            this.Content = new MigrationRunnerToolWindowControl();
        }
    }
}
