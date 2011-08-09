using NHibernate;

namespace Domain.Persistence
{
    public interface ISessionFactory
    {
        ISession OpenSession();
    }
}