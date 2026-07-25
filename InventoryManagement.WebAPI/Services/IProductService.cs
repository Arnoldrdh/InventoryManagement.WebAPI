using InventoryManagement.WebAPI.Models;


namespace InventoryManagement.WebAPI.Services
{
    public interface IProductService
    {

        List<ProductResponse> GetAllProduct();
        ProductResponse? GetById(int id);
        ProductResponse? Create(ProductRequest request);
        ProductResponse? Update(int id, ProductRequest request);
        bool Delete(int id);

        
    }
}
