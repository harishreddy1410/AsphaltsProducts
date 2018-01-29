using AsphaltsProducts.XUnitTests.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AsphaltsProducts.XUnitTests.Fixtures
{
    public class ProductServiceTests : IClassFixture<ProductServiceFixture>, IDisposable
    {
        BaseServiceLayer baseServiceLayer = BaseServiceLayer.Instance;
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
