namespace WebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int SupplierId { get; set; }        
        public virtual Supplier Supplier { get; set; }
    }
}
