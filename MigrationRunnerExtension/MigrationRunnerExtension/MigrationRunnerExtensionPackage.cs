using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace MigrationRunnerExtension
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(MigrationRunnerExtensionPackage.PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(MigrationRunnerToolWindow), Orientation = ToolWindowOrientation.Left, Style = VsDockStyle.AlwaysFloat)]
    public sealed class MigrationRunnerExtensionPackage : AsyncPackage
    {
        public const string PackageGuidString = "e57d496e-315d-4cad-83c9-b1b43543270b";

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await MigrationRunnerToolWindowCommand.InitializeAsync(this);
        }

    }
}
