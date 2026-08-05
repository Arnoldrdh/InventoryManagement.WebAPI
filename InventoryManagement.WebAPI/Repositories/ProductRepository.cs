using InventoryManagement.WebAPI.Data;
using InventoryManagement.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.WebAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;

    }

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product?> Add(Product product)
    {
        _context.Products.Add(product);

        await _context.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> Update(Product product)
    {
        var existingProduct = _context.Products.FirstOrDefault(prod => prod.Id == product.Id);
        
        if (existingProduct == null)
        {
            return null;
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;

        await _context.SaveChangesAsync();

        return existingProduct;
    }

    public async Task<bool> Delete(int id)
    {
        var productDeleted = _context.Products.FirstOrDefault(p => p.Id == id);

        if (productDeleted == null)
        {
            return false;
        }

        _context.Remove(productDeleted);
        await _context.SaveChangesAsync();

        return true;
    }
}