using Autofac;
using DevSkill.DevTrack.ClientTool.Helpers;
using DevSkill.DevTrack.ClientTool.Models.ConfigurationObjects;
using ElectronNET.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using DevSkill.DevTrack.ClientEngine;
using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;
using DevSkill.DevTrack.ClientEngine.Contexts;

namespace DevSkill.DevTrack.ClientTool
{
    public class Startup
    {
        private IElectronWindowHelper _electronWindowHelper;
        private IProgramDataLocationAdapter _programDataLocationAdapter;
        private IDirectoryAdapter _directoryAdapter;

        public IWebHostEnvironment WebHostEnvironment { get; set; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings{env.EnvironmentName}", optional: true)
                .AddEnvironmentVariables();

            WebHostEnvironment = env;
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddElectron();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<ElectronWindowOptions>(Configuration.GetSection("ElectronWindow"));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new ClientToolModule());
            builder.RegisterModule(new ClientEngineModule());
        }

        private string GetDirectoryPrefix()
        {
            var directoryPrefix = _directoryAdapter.CombinePath(_programDataLocationAdapter.Location,
                Configuration.GetValue<string>("ProgramDataFolderStructure:RootFolder"),
                Configuration.GetValue<string>("ProgramDataFolderStructure:DatabaseFolder")
            );

            if (!_directoryAdapter.DoesExists(directoryPrefix))
                _directoryAdapter.CreateDirectory(directoryPrefix);

            return directoryPrefix;
        }

        private (string connectionString, string migrationAssemblyName) GetConnectionStringAndAssemblyName()
        {
            var directoryPrefix = GetDirectoryPrefix();

            var connectionString =
                $"Data Source={directoryPrefix}\\{Configuration.GetConnectionString("ClientConnectionString")}";

            var migrationAssemblyName = typeof(Startup).Assembly.FullName;
            return (connectionString, migrationAssemblyName);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IElectronWindowHelper electronWindowHelper,
            IProgramDataLocationAdapter programDataLocationAdapter,
            IDirectoryAdapter directoryAdapter
        )
        {
            _electronWindowHelper = electronWindowHelper;
            _programDataLocationAdapter = programDataLocationAdapter;
            _directoryAdapter = directoryAdapter;

            var (connectionString, migrationAssemblyName) = GetConnectionStringAndAssemblyName();

            using var db = new ClientDbContext(connectionString, migrationAssemblyName);
            db.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            if (HybridSupport.IsElectronActive)
            {
                ElectronBootstrap();
            }
        }

        public async void ElectronBootstrap()
            => await _electronWindowHelper.SwitchToWindow(Enums.WindowEnum.MainWindow);
    }
}