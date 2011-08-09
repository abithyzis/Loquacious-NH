using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Domain.NHByCode.Mapping
{
    public class CustomerMap : ClassMapping<Customer>
    {
        public CustomerMap()
        {
            Property(x => x.Name);
            Property(x => x.Email);

            Set(x => x.Orders, set =>
                                {
                                    set.Key(key =>
                                    {
                                        key.Column("OrderId");
                                        key.ForeignKey("FK_Customer_Orders");
                                    });
                                    set.Table("Customer_Order");
                                    set.Cascade(Cascade.All.Include(Cascade.Remove));
                                    set.Fetch(CollectionFetchMode.Subselect);
                                },
                                ce => ce.ManyToMany(m => m.Column("CustomerId")));
        }
    }
}