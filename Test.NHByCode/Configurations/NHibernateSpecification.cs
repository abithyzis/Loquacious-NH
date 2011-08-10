using System;
using System.Data.SqlServerCe;
using Domain.NHByCode.Bootstrapper;
using Domain.NHCommon;
using Domain.NHCommon.Config;
using NHibernate.Tool.hbm2ddl;
using Test.Common;

namespace Test.NHByCode.Configurations
{
    public abstract class NHibernateSpecification
    {
        protected static IConfigurationProvider ConfigurationProvider;
        protected static NHibernateSessionFactory SessionFactory;

        public void Context()
        {
            Upgrade();
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

        private void Upgrade()
        {
            try
            {
                const string connectionString = @"Data Source=App_Data\tests.sdf";
                var ce = new SqlCeEngine(connectionString);
                ce.Upgrade(connectionString);
            }
            catch (Exception)
            {
                // throw;
            }
        }
    }
}
