using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;
        public ProductRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string Id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, Id);

            DeleteResult deleteResult = await _context
                                                .Products
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> GetProduct(string Id)
        {
            return await _context.Products.Find(p => p.Id == Id).FirstOrDefaultAsync();
           // return await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);



        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);

            return await _context
                            .Products
                           .Find(filter)
                           //.Find(p=>p.Name ==  categoryName)
                            .ToListAsync();
        }

        public async Task<Product> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Name, name);
            // MongoCollection  
            return await _context
                            .Products
                            .Find(p=>p.Name==name).FirstOrDefaultAsync();
                           // .Find(p=>p.Name==name)
                           // .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _context
                                        .Products
                                       // .ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);
                                       .ReplaceOneAsync(p => p.Id == product.Id, product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

       

      
    }
}
