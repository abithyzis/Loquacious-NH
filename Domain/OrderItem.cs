namespace Domain
{
    public class OrderItem : Entity
    {
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Quantity { get; set; }
    }
}