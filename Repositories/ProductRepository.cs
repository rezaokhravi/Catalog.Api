using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Constractor

        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _context = catalogContext;
        }

        #endregion

        #region Product Repo

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Find(
                p => true
            ).ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context.Products.Find(p
                => p.Id == id
            ).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _context.Products.Find(
                filter: p => p.Name == name
            ).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            return await _context.Products.Find(
                filter: p => p.Category == category
            ).ToListAsync();
        }

        public async Task CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult =
                await _context.Products.ReplaceOneAsync(
                    filter: p => p.Id == product.Id,
                    replacement: product
                );

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deleteProduct =
                await _context.Products.DeleteOneAsync(
                    filter: p => p.Id == id
                );
            
            return deleteProduct.IsAcknowledged &&
                   deleteProduct.DeletedCount > 0;
        }

        #endregion
    }
}