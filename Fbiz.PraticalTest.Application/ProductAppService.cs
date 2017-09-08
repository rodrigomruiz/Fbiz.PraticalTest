using System;
using System.Collections.Generic;
using Fbiz.PraticalTest.Application.Interface;
using Fbiz.PraticalTest.Domain.Entities;
using Fbiz.PraticalTest.Domain.Interfaces.Services;

namespace Fbiz.PraticalTest.Application
{
    public class ProductAppService : AppServiceBase<Product>, IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IProductService productService)
            : base (productService)
        {
            _productService = productService;
        }

        public IEnumerable<Product> GetByActiveOrNotActive(bool active)
        {
            return _productService.GetByActiveOrNotActive(active);
        }

        public IEnumerable<Product> SearchByName(string name)
        {
            return _productService.SearchByName(name);
        }
    }
}
