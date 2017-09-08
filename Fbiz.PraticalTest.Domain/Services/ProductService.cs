using System;
using System.Collections.Generic;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Domain.Interfaces.Repositories;
using Fbiz.PraticalTest.Domain.Interfaces.Services;

namespace Fbiz.PraticalTest.Domain.Services
{
    public class ProductService : ServiceBase<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
            : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetByActiveOrNotActive(bool active)
        {
            return _productRepository.GetByActiveOrNotActive(active);
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            return _productRepository.SearchByName(name);
        }
    }
}
