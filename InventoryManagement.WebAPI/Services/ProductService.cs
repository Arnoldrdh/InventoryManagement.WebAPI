using InventoryManagement.WebAPI.Models;
using InventoryManagement.WebAPI.Repositories;

namespace InventoryManagement.WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            var product = await _productRepository.GetAll();

            return product.Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            }).ToList();
        }

        public async Task<ProductResponse?> GetById(int id)
        {
            var product = await _productRepository.GetById(id);

            if (product == null)
                return null;

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public async Task<ProductResponse> Create(ProductRequest request)
        {
            var isCategoryExist = await _categoryRepository.GetById(request.CategoryId);

            if (isCategoryExist == null)
            {
                throw new KeyNotFoundException("Category not found.");
            }

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                CategoryId = request.CategoryId
            };

            var productResponse = await _productRepository.Add(product);

            return new ProductResponse
            {
                Id = productResponse.Id,
                Name = productResponse.Name,
                Price = productResponse.Price,
                Stock = productResponse.Stock
            };
        }


        public async Task<ProductResponse?> Update(int id, ProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

            var updatedProduct = await _productRepository.Update(product);

            if(updatedProduct == null)
            {
                return null;
            }

            return new ProductResponse
            {
                Name = updatedProduct.Name,
                Price = updatedProduct.Price,
                Stock = updatedProduct.Stock
            };
        }


        public async Task<bool> Delete(int id)
        {
            return await _productRepository.Delete(id);
        }




    }
}
