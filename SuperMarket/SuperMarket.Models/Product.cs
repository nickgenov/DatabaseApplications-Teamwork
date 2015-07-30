namespace SuperMarket.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int MeasureId { get; set; }

        public virtual Measure Measure { get; set; }
    }
}
