using System;
using System.Collections.Generic;
using System.Linq;
using AsphaltsProducts.Domain.Models.ECommerce;
using AsphaltsProducts.Infrastructure.Contexts;
using AsphaltsProducts.Service.Layer.ECommerce.ProductsService.Dto;
using AutoMapper;

namespace AsphaltsProducts.Service.Layer.ECommerce.ProductsService
{
    public class ProductService : IProductService
    {
        private readonly IAsphaltsDbContext _asphaltsDbContext;
        private readonly IMapper _mapper;
        public ProductService(IAsphaltsDbContext asphaltsDbContext,
            IMapper mapper)
        {
            _asphaltsDbContext = asphaltsDbContext;
            _mapper = mapper;
        }
        public List<ProductDto> GetProductsForDashboard()
        {
           return _mapper.Map<List<ProductDto>>(_asphaltsDbContext.Products.Take(30).ToList());
        }
    }
}
