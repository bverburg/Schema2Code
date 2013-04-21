using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using AutoMapper.Mappers;
using Ninject;
using Schema2Code.Mapping;

namespace Schema2Code.Inject
{
    public class AutoMapperModule : Ninject.Modules.NinjectModule
    {
        private Assembly[] assemblies = null;
        public Assembly[] Assemblies
        {
            get { return assemblies ?? AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().FullName.StartsWith("Schema2")).ToArray(); }
            set { this.assemblies = value; }
        }

        public override void Load()
        {

            Bind<ConfigurationStore>().ToMethod(ctx =>
            {
                var factory = ctx.Kernel.Get<ITypeMapFactory>();
                var cfg = new ConfigurationStore(factory, MapperRegistry.AllMappers());
                cfg.ConstructServicesUsing(x => ctx.Kernel.Get(x));

                cfg.LoadProfiles(ctx.Kernel, Assemblies);
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;

                cfg.AssertConfigurationIsValid();
                return cfg;
            }).InSingletonScope();

            Bind<IConfigurationProvider>().ToBound().Get<ConfigurationStore>();
            Bind<IConfiguration>().ToBound().Get<ConfigurationStore>();
            Bind<IMappingEngine>().To<MappingEngineDelegate>();
            Bind<MappingEngine>().ToSelf();
            Bind<ITypeMapFactory>().To<TypeMapFactory>();
        }
    }
}
