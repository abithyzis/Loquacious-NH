using System;
using System.Collections.Generic;
using NHibernate.Mapping.ByCode;

namespace Domain.NHByCode.Mapping
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

        public static void WithConventions(this ModelMapper mapper)
         {
             mapper.BeforeMapClass += (modelInspector, type, classCustomizer) =>
                                         {
                                             classCustomizer.Id(c => c.Column(type.Name + "Id"));
                                             classCustomizer.Id(c => c.Generator(Generators.GuidComb));
                                             classCustomizer.Table(ReservedTableNameHandler(type));
                                          };
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