namespace InventoryManagement.WebAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Product> products { get; set; } = new List<Product>();
    }
}
