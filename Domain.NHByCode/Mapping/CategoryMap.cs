﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Domain.NHByCode.Mapping
{
    class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            // Mapping of Id here will take precedence over the 
            // global conventions configured in the ModelMapper.
            //Id(x => x.Id, map =>
            //{
            //    map.Column("Id");
            //    map.Generator(Generators.GuidComb);
            //});

            Property(x => x.Name, m => m.Length(450));
            Property(x => x.Description, m => m.Length(2000));

            Bag(x => x.SubCategories, bag =>
                                          {
                                              bag.Key(k => k.Column("ParentCategoryId"));
                                              bag.Inverse(true);
                                          } ,
                                       ce => ce.OneToMany());

            ManyToOne(x => x.Parent, manyToOne =>
                                         {
                                             manyToOne.Column("ParentCategoryId");
                                             manyToOne.Lazy(LazyRelation.NoLazy);
                                             manyToOne.NotNullable(false);
                                         });
        }
    }
}
