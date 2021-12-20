using Autofac;
using DevSkill.DevTrack.ClientTool.Helpers;
using DevSkill.DevTrack.ClientTool.Stores;

namespace DevSkill.DevTrack.ClientTool
{
    public class ClientToolModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WindowStore>().As<IWindowStore>()
                .SingleInstance();
            builder.RegisterType<ElectronWindowHelper>().As<IElectronWindowHelper>()
                .SingleInstance();
            builder.RegisterType<ElectronTrayHelper>().As<IElectronTrayHelper>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}
