using AsphaltsProducts.Service.Layer.ECommerce.ProductsService;
using AsphaltsProducts.XUnitTests.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AsphaltsProducts.XUnitTests.Fixtures
{
    public class ProductServiceFixture :  IDisposable
    {
        BaseServiceLayer _serviceLayer;
        IProductService _productService;

        public ProductServiceFixture()
        {
            serviceLayer = new BaseServiceLayer();
            _productService = new ProductService(_serviceLayer.);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
