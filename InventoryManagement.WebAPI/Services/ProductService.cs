using InventoryManagement.WebAPI.Models;
using InventoryManagement.WebAPI.Repositories;

namespace InventoryManagement.WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductResponse> GetAllProduct()
        {
            var product = _productRepository.GetAll();

            return product.Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            }).ToList();
        }

        public ProductResponse? GetById(int id)
        {
            var product = _productRepository.GetById(id);

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

        public ProductResponse Create(ProductRequest request)
        {
            

            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

             _productRepository.Add(product);

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }


        public ProductResponse Update(int id, ProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

            var updatedProduct = _productRepository.Update(product);

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


        public bool Delete(int id)
        {
            return _productRepository.Delete(id);
        }




    }
}
