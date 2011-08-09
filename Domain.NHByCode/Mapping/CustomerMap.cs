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
            Bag(x => x.Orders, bag =>
                                {
                                    bag.Key(key =>
                                    {
                                        key.Column("OrderId");
                                        key.ForeignKey("FK_Customer_Orders");
                                    });
                                    bag.Table("Customer_Orders");
                                    bag.Cascade(Cascade.All.Include(Cascade.Remove));
                                    bag.Fetch(CollectionFetchMode.Subselect);
                                },
                                ce => ce.ManyToMany(m => m.Column("ProductId")));
        }
    }
}