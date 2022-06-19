﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductWithCategory()
        {
            //Eager loading -> Product cekilirken aynı zamanda category ide çekme işlemi
            return await _context.Products.Include(x=>x.Category).ToListAsync(); // -> Eager

            //Lazy loading -> Product cekilirken daha sonra category ide çekme işlemi
        }
    }
}
