using ApiTest.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ApiTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private const string DataFilePath = "data.json";
        private Data data;

        public ProductRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (File.Exists(DataFilePath))
            {
                var jsonData = File.ReadAllText(DataFilePath);
                data = JsonSerializer.Deserialize<Data>(jsonData) ?? new Data();
            }
            else
            {
                data = new Data();
            }
        }

        public IEnumerable<Product> GetAllProducts() => data.Products;

        public Product? GetProductById(int id) => data.Products.FirstOrDefault(p => p.Id == id);

        public void AddProduct(Product product)
        {
            data.Products.Add(product);
            SaveData();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                SaveData();
            }
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                data.Products.Remove(product);
                SaveData();
            }
        }

        private void SaveData()
        {
            var jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(DataFilePath, jsonData);
        }
    }
}
