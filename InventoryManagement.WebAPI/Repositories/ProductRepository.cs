using InventoryManagement.WebAPI.Models;

namespace InventoryManagement.WebAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public ProductRepository()
    {
        _products.Add(new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 15000000,
            Stock = 5
        });

        _products.Add(new Product
        {
            Id = 2,
            Name = "Mouse",
            Price = 200000,
            Stock = 20
        });
    }

    public List<Product> GetAll()
    {
        Console.WriteLine(_products);
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public Product Add(Product product)
    {
        int nextId = _products.Max(p => p.Id) + 1;

        product.Id = nextId;

        _products.Add(product);
        return product;
    }

    public Product? Update(Product product)
    {
        var existingProduct = _products.FirstOrDefault(prod => prod.Id == product.Id);
        Console.WriteLine(existingProduct);
        if (existingProduct == null)
        {
            return null;
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;

        return existingProduct;
    }

    public bool Delete(int id)
    {
        var productDeleted = _products.FirstOrDefault(p => p.Id == id);

        if (productDeleted == null)
        {
            return false;
        }

        _products.Remove(productDeleted);

        return true;
    }
}