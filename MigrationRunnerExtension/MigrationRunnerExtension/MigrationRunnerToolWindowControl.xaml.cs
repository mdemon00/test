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
using MigrationRunnerExtension.Services;

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

            var assemblyService = new AssemblyService();
            var assemblies = assemblyService.GetAssemblies(dte.Solution.Projects);

            var test = assemblies[4];
            var x = test.GetReferencedAssemblies();

            var y = Assembly.Load(x[9]);

            var project = dte.Solution.Projects;


            
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
               "",
                "MigrationRunnerToolWindow");
        }
    }
}