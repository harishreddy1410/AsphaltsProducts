using AsphaltsProducts.Infrastructure.Contexts;
using AsphaltsProducts.Service.Layer.ECommerce.ProductsService;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsphaltsProducts.XUnitTests.Base
{
    public class BaseServiceLayer : IDisposable
    {

        private AsphaltsDbContext _asphaltsDbContext;
        private IMapper _mapper;


        public Mock<IProductService> _mockProductService = new Mock<IProductService>();
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
