using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Domain.NHByCode.Mapping
{
    public class OrderMap : ClassMapping<Order>
    {
        public OrderMap()
        {
            //ManyToOne(x => x.Customer, manyToOne =>
            //                               {
            //                                   manyToOne.Column("OrdersId");
            //                                   manyToOne.Cascade(Cascade.All);
            //                                   manyToOne.NotNullable(true);
            //                               });

            Property(x => x.OrderDate);
        }
    }
}