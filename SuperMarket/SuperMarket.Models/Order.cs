namespace SuperMarket.Models
{
    class Order
    {
        public int Id { get; set; }

        public double Quantity { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public float discount { get; set; }
    }
}
