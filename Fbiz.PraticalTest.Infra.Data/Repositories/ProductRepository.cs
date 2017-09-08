using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Fbiz.PraticalTest.Infra.Data.Repositories
{
    public class ProductRepository :  RepositoryBase<Product>, IProductRepository
    {
        public IEnumerable<Product> GetByActiveOrNotActive(bool active)
        {
            return Db.Products
                    .Where(p => p.Active == active)
                    .OrderBy(p => p.Name);
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            return Db.Products.Where(p => p.Name == name);
        }
    }
}
