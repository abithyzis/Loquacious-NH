using System.Collections.Generic;

namespace Domain
{
    public class Customer : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}