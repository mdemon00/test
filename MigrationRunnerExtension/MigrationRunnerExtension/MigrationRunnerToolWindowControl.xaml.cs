using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;

namespace MigrationRunnerExtension
{
    public partial class MigrationRunnerToolWindowControl : UserControl
    {
        public MigrationRunnerToolWindowControl()
        {
            this.InitializeComponent();
        }

        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var dte = ServiceProvider.GlobalProvider.GetService(typeof(DTE)) as DTE2;
            MessageBox.Show(
                dte.Version,
                "MigrationRunnerToolWindow");
        }
    }
}