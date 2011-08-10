using System;
using System.Collections.Generic;
using NHibernate.Mapping.ByCode;

namespace Domain.NHByConvention.Mapping
{
    /// <summary>
    /// Applies global common conventions to the mapped entities. 
    /// For clarity configurations set here can be overriden in 
    /// an entity's specific mapping file.  For example; The Id 
    /// convention here is set to TableNameId but if the Id column 
    /// was mapped in the entity's mapping file then the entity's 
    /// mapping file configuration will take precedence.
    /// </summary>
    public static class Conventions
    {
        private static readonly List<string> ReservedSqlKeywords = new List<string> {"Order", "User", "Index"};

        public static void WithConventions(this ConventionModelMapper mapper)
        {
            var baseEntityType = typeof (Entity);
            mapper.IsEntity(
                (type, declared) => baseEntityType.IsAssignableFrom(type) && baseEntityType != type && !type.IsInterface);
            mapper.IsRootEntity((type, declared) => baseEntityType.Equals(type.BaseType));

            mapper.BeforeMapManyToOne +=
                (modelInspector, propertyPath, map) =>
                map.Column(propertyPath.LocalMember.GetPropertyOrFieldType().Name + "Id");
            mapper.BeforeMapManyToOne += (modelInspector, propertyPath, map) => map.Cascade(Cascade.Persist);
            mapper.BeforeMapBag +=
                (modelInspector, propertyPath, map) =>
                map.Key(keyMapper => keyMapper.Column(propertyPath.GetContainerEntity(modelInspector).Name + "Id"));
            mapper.BeforeMapBag += (modelInspector, propertyPath, map) => map.Cascade(Cascade.All);

            mapper.BeforeMapClass += (modelInspector, type, classCustomizer) =>
                                         {
                                             classCustomizer.Id(c => c.Column(type.Name + "Id"));
                                             classCustomizer.Id(c => c.Generator(Generators.GuidComb));
                                             classCustomizer.Table(ReservedTableNameHandler(type));
                                         };

            mapper.Class<Entity>(map =>
                                     {
                                         map.Id(x => x.Id, m => m.Generator(Generators.GuidComb));
                                         map.Version(x => x.Version, m => m.Generated(VersionGeneration.Always));
                                     });

            mapper.Class<Product>(map => map.Set(x => x.Categories,
                                                 set =>
                                                     {
                                                         set.Key(key =>
                                                                     {
                                                                         key.Column("CategoryId");
                                                                         key.ForeignKey("FK_Product_Category_CategoryId");
                                                                     });
                                                         set.Table("Product_Category");
                                                     },
                                                 ce => ce.ManyToMany(m => m.Column("ProductId"))));


            mapper.Class<Category>(map => map.Set(x => x.Products, 
                                                set =>
                                                    {
                                                        set.Key(key =>
                                                                    {
                                                                        key.Column("ProductId");
                                                                        key.ForeignKey(
                                                                            "FK_Product_Category_ProductId");
                                                                    });
                                                        set.Table("Product_Category");
                                                    },
                                                  ce => ce.ManyToMany(m => m.Column("CategoryId"))));
        }

        private static string ReservedTableNameHandler(Type type)
        {
            // http://www.nhforge.org/doc/nh/en/index.html#mapping-quotedidentifiers
            var tableName = type.Name;
            return ReservedSqlKeywords.Contains(type.Name) 
                ? "`" + tableName + "`" 
                : tableName;
        }
    }
}