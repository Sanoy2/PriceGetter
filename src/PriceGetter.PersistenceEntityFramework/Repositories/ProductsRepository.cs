﻿using PriceGetter.Core.Interfaces.Repositories;
using PriceGetter.Core.Models.Entities;
using PriceGetter.Core.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PriceGetter.PersistenceEntityFramework.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly PriceGetterDbContext db;

        public ProductsRepository(PriceGetterDbContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task Add(Product product)
        {
            IEnumerable<Product> allProducts = await this.Get();
            if (allProducts.Contains(product) == false)
            {
                await db.AddAsync(product);
            }
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var products = await this.db.Products
                .Include(x => x.Prices)
                .ToListAsync();

            return products;
        }

        public async Task<Product> Get(Guid productId)
        {
            return await this.db.Products
                .Include(x => x.Prices)
                .FirstAsync(x => x.Id == productId);
        }

        public async Task<Product> Get(Name name)
        {
            return await this.db.Products
                .Include(x => x.Prices)
                .FirstAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Product>> GetMonitored()
        {
            var allProducts = await this.Get();

            return allProducts.Where(x => x.MonitoringActive).ToList();
        }

        public void Remove(Product product)
        {
            this.db.Products.Remove(product);
        }
    }
}
