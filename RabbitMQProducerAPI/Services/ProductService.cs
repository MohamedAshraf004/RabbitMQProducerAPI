using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQProducerAPI.Data;
using RabbitMQProducerAPI.Models;

namespace RabbitMQProducerAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly RabbitMQContext _dbContext;
        public ProductService(RabbitMQContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
        }
        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }
        public bool DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Products.FirstOrDefault(x => x.ProductId == Id);
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result is not  null ? true : false;
        }
    }
}
