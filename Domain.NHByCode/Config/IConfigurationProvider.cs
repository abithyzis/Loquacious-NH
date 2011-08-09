using NHibernate;
using NHibernate.Cfg;

namespace Domain.NHByCode.Config
{
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Access the configuration
        /// </summary>
        Configuration Configuration { get; }

        /// <summary>
        /// Builds a new ISessionFactory from the current configuration
        /// </summary>
        ISessionFactory BuildSessionFactory();
    }
}