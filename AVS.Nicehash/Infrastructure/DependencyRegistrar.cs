using Autofac;
using AVS.CoreLib.DependencyRegistrar;
using AVS.CoreLib.Infrastructure;
using AVS.CoreLib.Infrastructure.Config;
using AVS.CoreLib.Services.Logger;
using AVS.Nicehash.Api;
using AVS.Nicehash.Api.Utils;

namespace AVS.Nicehash.Infrastructure
{
    public class DependencyRegistrar : DependencyRegistrarBase
    {
        public override bool UseDatabase => false;

        protected override void RegisterServices(ContainerBuilder builder, ITypeFinder typeFinder, IAppConfig config)
        {
            builder.Register(c => config).AsSelf().InstancePerLifetimeScope();
            var client = new NiceHashClient("582959", "59bdfba6-fff7-20a2-6c3d-6c8235b1d8dc");
            builder.Register(c => client).As<NiceHashClient>().InstancePerLifetimeScope();
            builder.RegisterType<OrderAdjustmentHelper>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<OnlineMarketViewController>().AsSelf().InstancePerLifetimeScope();
            
            builder.RegisterType<Logger>().As<ILogger>().InstancePerLifetimeScope();
            builder.RegisterType<Logger>().As<IBufferedLogger>().InstancePerLifetimeScope();
            
        }

        public override int Order => 0;
    }
}
