using NHibernate.Mapping.ByCode.Conformist;

namespace Domain.NHByCode.Mapping
{
    class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Property(x => x.Name, m => m.Length(450));
            Property(x => x.Description, m => m.Length(2000));
        }
    }
}
