using NHibernate.Mapping.ByCode.Conformist;

namespace Domain.NHByCode.Mapping
{
    class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            Property(x => x.Name, m => m.Length(450));
            Property(x => x.Description, m => m.Length(10000));

            Set(x => x.Categories, set =>
                                       {
                                           set.Key(key =>
                                                       {
                                                           key.Column("CategoryId");
                                                           key.ForeignKey("FK_Product_Category_CategoryId");
                                                       });
                                           set.Table("Product_Category");
                                       },
                                    ce => ce.ManyToMany(m => m.Column("ProductId")));
        }
    }
}
