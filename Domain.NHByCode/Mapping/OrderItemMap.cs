using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Domain.NHByCode.Mapping
{
    public class OrderItemMap : ClassMapping<OrderItem>
    {
        public OrderItemMap()
        {
            Property(x => x.Price, p => p.NotNullable(true));
            Property(x => x.Quantity, p => p.NotNullable(true));

            ManyToOne(x => x.Order, manyToOne =>
                                    {
                                        manyToOne.Column("OrderId");
                                        manyToOne.Cascade(Cascade.All);
                                        manyToOne.NotNullable(true);
                                    });

            ManyToOne(x => x.Product, manyToOne =>
                                    {
                                        manyToOne.Column("ProductId");
                                        manyToOne.Cascade(Cascade.All);
                                        manyToOne.NotNullable(true);
                                    });
        }
    }
}