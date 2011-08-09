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
            Bag(x => x.Orders, map =>
                                   {
                                       map.Table("Customer_Orders");
                                       map.Key(k => k.Column("CustomerId"));
                                       map.Cascade(Cascade.All);
                                   });
            
        }
    }
}