using NHibernate.Mapping.ByCode.Conformist;

namespace Domain.NHByCode.Mapping
{
    public class OrderItemMap : ClassMapping<OrderItem>
    {
        public OrderItemMap()
        {
            //ManyToOne(x => x.Order, map => map.Column("OrderId"));
            //Property(x => x.Product);
            Property(x => x.Price);
            Property(x => x.Quantity);
        }
    }
}