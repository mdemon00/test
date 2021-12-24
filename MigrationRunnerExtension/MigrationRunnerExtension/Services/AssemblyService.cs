using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using EnvDTE;

namespace MigrationRunnerExtension.Services
{
    public class AssemblyService : IAssemblyService
    {
        public List<Assembly> GetAssemblies(Projects projects)
        {
            List<Assembly> assemblies = new List<Assembly>();

            foreach (dynamic project in projects)
            {
                var fullProjectPath = project.Properties.Item("FullPath").Value.ToString();
                var outputDir = Path.Combine(fullProjectPath, project.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value.ToString());
                var outputFileName = Path.Combine(outputDir, project.Properties.Item("OutputFileName").Value.ToString());
                var assemblyName = new AssemblyName(project.Properties.Item("AssemblyName").Value.ToString());
                assemblyName.CodeBase = outputFileName;
                try
                {
                    var projectAssembly = Assembly.Load(assemblyName);
                    assemblies.Add(projectAssembly);
                }
                catch (Exception ex)
                {
                    //TODO: some diag info (especially when the project is not built yet) could be very useful.
                }
            }

            return assemblies;
        }
    }
}