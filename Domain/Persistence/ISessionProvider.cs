using NHibernate;

namespace Domain.Persistence
{
    public interface ISessionProvider
    {
        ISession Session { get; }
    }
}