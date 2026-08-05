using InventoryManagement.WebAPI.Models;

namespace InventoryManagement.WebAPI.Repositories
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAll();
        public Task<Category?> GetById(int id);
    }
}
