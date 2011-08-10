using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Common;
using Domain.NHByCode.Mapping;
using Domain.NHCommon;
using Domain.NHCommon.Config;
using Domain.Persistence;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace Domain.NHByCode.Bootstrapper
{
    public class NHibernateFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
                Component.For<ISessionFactory>().ImplementedBy<NHibernateSessionFactory>().LifeStyle.Singleton,
                Component.For<ISessionProvider>().ImplementedBy<NHibernateSessionProvider>().LifeStyle.PerWebRequest,
                Component.For<IConfigurationProvider>().LifeStyle.Singleton.UsingFactoryMethod(CreateConfigurationProvider));
        }

        public static IConfigurationProvider CreateConfigurationProvider()
        {
            var configFilePath = PathHelpers.InCurrentAppDomain(Constants.NHibernateConfigFileName);
            var configuration = new Configuration();
            configuration.Configure(configFilePath);

            var mapper = new ModelMapper();
            mapper.WithConventions();
            mapper.WithMappings(configuration);

            return new ConfigurationProvider(configuration);
        }
    }
}