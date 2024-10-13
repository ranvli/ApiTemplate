using ApiTest.Entities;
using ApiTest.Repositories;
using System.Collections.Generic;

namespace ApiTest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts() => _productRepository.GetAllProducts();

        public Product? GetProductById(int id) => _productRepository.GetProductById(id);

        public void AddProduct(Product product) => _productRepository.AddProduct(product);

        public void UpdateProduct(Product product) => _productRepository.UpdateProduct(product);

        public void DeleteProduct(int id) => _productRepository.DeleteProduct(id);
    }
}

