using System.Collections.Generic;
using AutoPoco;
using AutoPoco.DataSources;
using AutoPoco.Engine;
using Domain;

namespace Test.Common
{
    public static class DataGenerator
    {
        private static IGenerationSessionFactory _factory;
        private static IGenerationSessionFactory GetFactory()
        {
            return AutoPocoContainer.Configure(x =>
            {
                x.Conventions(c => c.UseDefaultConventions());
                x.AddFromAssemblyContainingType<Customer>();

                x.Include<Category>()
                    .Setup(c => c.Name).Use<CategoryNameSource>()
                    .Setup(c => c.Description).Use<LoremIpsumSource>()
                    .Setup(c => c.Parent).Value(null)
                    .Setup(c => c.SubCategories).Value(new List<Category>())
                    .Setup(c => c.Products).Value(new List<Product>());

                x.Include<Product>()
                    .Setup(c => c.Name).Use<FirstNameSource>()
                    .Setup(c => c.Description).Use<LoremIpsumSource>()
                    .Setup(c => c.Categories).Value(new List<Category>())
                    .Setup(c => c.Discontinued).Value(false);
            });
        }

        public static IGenerationSession GetSession()
        {
            if (_factory == null)
                _factory = GetFactory();

            return _factory.CreateSession();
        }
    }
}