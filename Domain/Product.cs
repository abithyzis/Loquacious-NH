using System.Collections.Generic;

namespace Domain
{
    public class Product : Entity
    {
        public Product()
        {
            //Categories = new List<Category>();
        }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        //public virtual IList<Category> Categories { get; set; }
        public virtual bool Discontinued { get; set; }
    }
}