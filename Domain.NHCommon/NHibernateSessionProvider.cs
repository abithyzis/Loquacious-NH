using Domain.Persistence;
using NHibernate;
using ISessionFactory = NHibernate.ISessionFactory;

namespace Domain.NHCommon
{
    public class NHibernateSessionProvider : ISessionProvider
    {
        private readonly ISessionFactory sessionFactory;
        private ISession session;

        public NHibernateSessionProvider(ISessionFactory sessionFactory)
        {
            this.sessionFactory = sessionFactory;
        }

        public ISession Session
        {
            get { return session ?? (session = sessionFactory.OpenSession()); }
        }
    }
}