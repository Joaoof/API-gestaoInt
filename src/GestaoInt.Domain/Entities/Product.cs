namespace GestaoInt.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name_Product { get; set; }
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        //public ProductStatus Status { get; set; }
        public string CategoryId { get; set; }
        public string SupplierId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public DateTime DeleteAt { get; set; } = DateTime.Now;

    }
}
