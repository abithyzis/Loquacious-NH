using Domain.NHByCode.Config;
using NHibernate;

namespace Domain.NHByCode
{
    public class NHibernateSessionFactory : Persistence.ISessionFactory
    {
        protected readonly IConfigurationProvider ConfigurationProvider;
        private readonly object @lock = new object();
        private ISessionFactory factory;

        public NHibernateSessionFactory(IConfigurationProvider configurationProvider)
        {
            ConfigurationProvider = configurationProvider;
        }

        public ISessionFactory Factory
        {
            get
            {
                lock (@lock)
                {
                    if (factory == null)
                    {
                        factory = ConfigurationProvider.BuildSessionFactory();
                    }
                }
                return factory;
            }
        }

        public virtual ISession OpenSession()
        {
            return Factory.OpenSession();
        }
    }
}
