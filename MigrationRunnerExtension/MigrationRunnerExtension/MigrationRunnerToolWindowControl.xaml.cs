using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Text;
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

            foreach (var assembly in assemblies)
            {

            }

            var test = assemblies[4];
            var x = test.GetReferencedAssemblies();

            var y = TypesHelper.GetLoadableTypes(Assembly.Load(x[17]));

            //for (var i = 0; i < Assembly.Load(x[9])..GetTypes().Length; i++ )
            //{
            //    try
            //    {
            //        y.Add(Assembly.Load(x[9]).GetTypes()[i]);
            //    }
            //    catch(Exception ex)
            //    {
            //        continue;
            //    }
            //}





            //try
            //{
            //    y = Assembly.Load(x[9]).GetTypes();
            //}
            //catch (ReflectionTypeLoadException ex)
            //{
            //    StringBuilder sb = new StringBuilder();
            //    foreach (Exception exSub in ex.LoaderExceptions)
            //    {
            //        sb.AppendLine(exSub.Message);
            //        FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
            //        if (exFileNotFound != null)
            //        {
            //            if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
            //            {
            //                sb.AppendLine("Fusion Log:");
            //                sb.AppendLine(exFileNotFound.FusionLog);
            //            }
            //        }
            //        sb.AppendLine();
            //    }
            //    string errorMessage = sb.ToString();
            //    //Display or log the error based on your application.
            //}

            var project = dte.Solution.Projects;

            var result = new List<string>();

            foreach (var t in y)
            {
                IEnumerable<Type> XX;
                try
                {
                     XX = TypesHelper.GetLoadableTypes(t.Assembly);
                }
                catch
                {
                    continue;
                }

                foreach (var type in XX)
                {
                    if (!type.IsClass || type.IsAbstract || !type.IsSubclassOf(typeof(DbContext))) continue;
                    //if (type == typeof(IdentityDbContext) || type.IsGenericType) continue;
                    //var connectionString = _commonService.GetConnectionString(assemblyPath);
                    //var context = (DbContext)Activator.CreateInstance(type, connectionString, assembly.FullName);
                    result.Add(type.FullName);
                }
            }

            //foreach (var reference in y.GetReferencedAssemblies())
            //{
            //    if (reference.FullName.StartsWith("System") || reference.FullName.StartsWith("Microsoft") || reference.FullName.StartsWith("mscorlib"))
            //        continue;

            //    Assembly referancedAssembly = null;
            //    try
            //    {
            //         referancedAssembly = Assembly.Load(reference);

            //    }
            //    catch (Exception ex)
            //    {
            //        continue;
            //    }

            //    foreach (var type in referancedAssembly.GetTypes())
            //    {
            //        if (!type.IsClass || type.IsAbstract || !type.IsSubclassOf(typeof(DbContext))) continue;
            //        //if (type == typeof(IdentityDbContext) || type.IsGenericType) continue;
            //        //var connectionString = _commonService.GetConnectionString(assemblyPath);
            //        //var context = (DbContext)Activator.CreateInstance(type, connectionString, assembly.FullName);
            //        result.Add(type.FullName);
            //    }
            //}

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