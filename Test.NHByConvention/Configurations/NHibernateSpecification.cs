using Domain.NHByConvention.Bootstrapper;
using Domain.NHCommon;
using Domain.NHCommon.Config;
using NHibernate.Tool.hbm2ddl;
using Test.Common;

namespace Test.NHByConvention.Configurations
{
    public abstract class NHibernateSpecification
    {
        protected static IConfigurationProvider ConfigurationProvider;
        protected static NHibernateSessionFactory SessionFactory;

        public void Context()
        {
            BuildConfigurationAndSessionFactory();
            CreateSchema();
            NHibernateProfilerInitialiser.Initialise();
        }

        protected static void CreateSchema()
        {
            new SchemaExport(ConfigurationProvider.Configuration).Execute(true, true, false);
        }

        private static void BuildConfigurationAndSessionFactory()
        {
            ConfigurationProvider = NHibernateFacility.CreateConfigurationProvider();
            SessionFactory = new NHibernateSessionFactory(ConfigurationProvider);
        }
    }
}
