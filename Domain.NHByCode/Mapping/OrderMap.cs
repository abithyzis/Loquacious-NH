using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Domain.NHByCode.Mapping
{
    public class OrderMap : ClassMapping<Order>
    {
        public OrderMap()
        {
            Property(x => x.OrderDate);

            ManyToOne(x => x.Customer, manyToOne =>
                                           {
                                               manyToOne.Column("CustomerId");
                                               manyToOne.Cascade(Cascade.All);
                                               manyToOne.NotNullable(true);
                                           });

            Bag(x => x.Items, bag =>
                                  {
                                      bag.Key(key =>
                                      {
                                          key.Column("OrderItemId");
                                          key.ForeignKey("FK_Order_OrderItem");
                                      });
                                      bag.Table("OrderItem");
                                      bag.Cascade(Cascade.All.Include(Cascade.Remove));
                                      bag.Fetch(CollectionFetchMode.Subselect);
                                  },
                               ce => ce.ManyToMany(m => m.Column("OrderId")));
        }
    }
}