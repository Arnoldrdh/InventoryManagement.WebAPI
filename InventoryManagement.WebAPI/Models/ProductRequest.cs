using System.ComponentModel.DataAnnotations;



namespace InventoryManagement.WebAPI.Models
{
    public class ProductRequest
    {
        [Required]
        public string Name { get; set; } = "";

        [Range(1,int.MaxValue)]
        public int Price { get; set; }

        [Range(1, int.MaxValue)]
        public int Stock { get; set; }
    }
}
