using InventoryManagement.WebAPI.Models;


namespace InventoryManagement.WebAPI.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product? GetById(int id);
        Product? Add(Product product);
        Product? Update(Product product);

        bool Delete(int id);
    }
}
