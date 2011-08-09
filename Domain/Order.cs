using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order : Entity
    {
        public virtual Customer Customer { get; set; }
        public virtual DateTime OrderDate { get; set; }
        //public virtual IEnumerable<OrderItem> Items { get; set; }
    }
}