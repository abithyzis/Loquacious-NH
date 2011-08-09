using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;

namespace Domain.NHByCode.Mapping
{
    public static class Mappings
    {
        public static void WithMappings(this ModelMapper mapper, Configuration configuration)
        {
            mapper.AddMappings(typeof(CategoryMap).Assembly.GetTypes());
            configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
         }
    }
}