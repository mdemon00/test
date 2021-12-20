using Autofac;
using DevSkill.DevTrack.ClientEngine.Adapters;
using DevSkill.DevTrack.ClientEngine.Adapters.Contracts;

namespace DevSkill.DevTrack.ClientEngine
{
    public class ClientEngineModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProgramDataLocationAdapter>().As<IProgramDataLocationAdapter>()
                .SingleInstance();
            builder.RegisterType<DirectoryAdapter>().As<IDirectoryAdapter>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
