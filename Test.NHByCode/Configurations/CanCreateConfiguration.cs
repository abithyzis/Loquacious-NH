using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Test.NHByCode.Configurations
{
    [TestFixture]
    public class CanCreateConfiguration : NHibernateSpecification
    {
        [SetUp]
        public void SetUpForEachTest()
        {
            Context();
        }

        [Test]
        public void it_can_generate_database_schema_sql_file()
        {
            const string fileName = @"..\..\outputssql\schema.sql";
            new SchemaExport(ConfigurationProvider.Configuration).SetOutputFile(fileName).Create(true, false);
        }

        [Test]
        public void it_can_create_actual_database_entities()
        {
            CreateSchema();
        }
    }
}