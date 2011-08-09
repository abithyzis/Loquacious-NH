using NHibernate.Mapping.ByCode.Conformist;

namespace Domain.NHByCode.Mapping
{
    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            Property(x => x.Name);
            Property(x => x.Email);
            //Bag(x => x.Orders, map => map.Key(k => k.Column("CustomerId")));
        }
    }
}