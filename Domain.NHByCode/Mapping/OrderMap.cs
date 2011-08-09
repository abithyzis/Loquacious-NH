using NHibernate;
using NHibernate.Mapping.ByCode.Conformist;

namespace Domain.NHByCode.Mapping
{
    public class OrderMap : ClassMapping<Order>
    {
        public OrderMap()
        {
            Table("Orders");
            //ManyToOne(x => x.Customer, map => map.Column("CustomerId"));
            Property(x => x.OrderDate);
            //Bag(x => x.Items, map => map.Key(k => k.Column("OrderId")));
        }
    }
}