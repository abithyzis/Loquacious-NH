using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace Domain.NHByConvention.Mapping
{
    public static class Mappings
    {
        public static void WithMappings(this ModelMapper mapper, Configuration configuration)
        {
            // Initially the Product table had a FK to Category
            // and Category table had a FK to Product.
            mapper.Class<Product>(map => map.Set(x => x.Categories,
                                                 set =>  {
                                                             set.Key(key =>
                                                             {
                                                                 key.Column("CategoryId");
                                                                 key.ForeignKey("FK_Product_Category_CategoryId");
                                                             });
                                                             set.Table("Product_Category");
                                                         },
                                                         ce => ce.ManyToMany(m => m.Column("ProductId"))));

            mapper.Class<Category>(map => map.Set(x => x.Products,
                                                set =>  {   set.Key(key =>
                                                            {
                                                                key.Column("ProductId");
                                                                key.ForeignKey(
                                                                    "FK_Product_Category_ProductId");
                                                            });
                                                            set.Table("Product_Category");
                                                        },
                                                  ce => ce.ManyToMany(m => m.Column("CategoryId"))));

            // Initially the SubCategories and Parent were NOT mapped.
            mapper.Class<Category>(map => map.Set(x => x.SubCategories, 
                                            set =>  {   set.Key(k => k.Column("ParentCategoryId"));
                                                        set.Inverse(true);
                                                    },
                                                    ce => ce.OneToMany()));

            mapper.Class<Category>(map => map.ManyToOne(x => x.Parent, 
                                            manyToOne =>    {
                                                                manyToOne.Column("ParentCategoryId");
                                                                manyToOne.Lazy(LazyRelation.NoLazy);
                                                                manyToOne.NotNullable(false);
                                                            }));

            var mapping = mapper.CompileMappingFor(typeof(Entity).Assembly.GetExportedTypes());
            configuration.AddDeserializedMapping(mapping, "l337");
         }
    }
}