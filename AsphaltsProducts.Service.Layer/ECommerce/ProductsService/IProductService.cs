using AsphaltsProducts.Domain.Models.ECommerce;
using AsphaltsProducts.Service.Layer.ECommerce.ProductsService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsphaltsProducts.Service.Layer.ECommerce.ProductsService
{
    public interface IProductService
    {
        List<ProductDto> GetProductsForDashboard();
    }
}
