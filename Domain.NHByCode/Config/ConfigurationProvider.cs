using NHibernate;
using NHibernate.Cfg;

namespace Domain.NHByCode.Config
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public ConfigurationProvider(Configuration configuration)
        {
            Configuration = configuration;
        }

        public Configuration Configuration { get; protected set; }

        public ISessionFactory BuildSessionFactory()
        {
            return Configuration.BuildSessionFactory();
        }
    }
}