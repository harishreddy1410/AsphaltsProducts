using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsphaltsProducts.Service.Layer.ECommerce.ProductsService;
using Microsoft.AspNetCore.Mvc;

namespace AsphaltsProducts.Presentation.Layer.Controllers
{
    public class ServiceTestController : Controller
    {
        IProductService _productService;
        public ServiceTestController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return Json(_productService.GetProductsForDashboard());
        }
    }
}