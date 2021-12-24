using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using EnvDTE;
using EnvDTE80;
using Microsoft.EntityFrameworkCore;
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

            var test = typeof(DbContext);

            Project project = dte.Solution.Projects.Item(1);
            List<Assembly> list = new List<Assembly>();


            string fullProjectPath = project.Properties.Item("FullPath").Value.ToString();
            string outputDir = Path.Combine(fullProjectPath, project.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value.ToString());
            string outputFileName = Path.Combine(outputDir, project.Properties.Item("OutputFileName").Value.ToString());
            AssemblyName assemblyName = new AssemblyName(project.Properties.Item("AssemblyName").Value.ToString());
            assemblyName.CodeBase = outputFileName;
            try
            {
                Assembly projectAssembly = Assembly.Load(assemblyName);
                list.Add(projectAssembly);
            }
            catch (Exception ex)
            {
                //TODO: some diag info (especially when the project is not built yet) could be very useful.
            }

            
            //foreach (var project in dte.Solution.Projects)
            //{
            //    var referancedAssembly = Assembly.Load(project.);
            //    foreach (var type in project.GetTypes())
            //    {
            //        if (!type.IsClass || type.IsAbstract || !type.IsSubclassOf(typeof(DbContext))) continue;
            //        if (type == typeof(IdentityDbContext) || type.IsGenericType) continue;
            //        var connectionString = _commonService.GetConnectionString(assemblyPath);
            //        var context = (DbContext)Activator.CreateInstance(type, connectionString, assembly.FullName);
            //        result.Add(context);
            //    }
            //}


            MessageBox.Show(
                test.FullName,
                "MigrationRunnerToolWindow");
        }
    }
}