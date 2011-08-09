using System.Collections.Generic;

namespace Domain
{
    public class Category : Entity
    {
        public Category()
        {
            //Products = new List<Product>();
            SubCategories = new List<Category>();
        }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Category Parent { get; set; }
        public virtual IEnumerable<Category> SubCategories { get; set; }

        //public virtual IList<Product> Products { get; set; }
    }
}