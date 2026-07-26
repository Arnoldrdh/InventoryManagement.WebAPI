using InventoryManagement.WebAPI.Models;


namespace InventoryManagement.WebAPI.Services
{
    public interface IProductService
    {

        Task<List<ProductResponse>> GetAllProducts();

        Task<ProductResponse?> GetById(int id);

        Task<ProductResponse> Create(ProductRequest request);

        Task<ProductResponse?> Update(int id, ProductRequest request);

        Task<bool> Delete(int id);


    }
}
