using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsphaltsProducts.Service.Layer.ECommerce.ProductsService;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AsphaltsProducts.Presentation.Layer.Models;
using AsphaltsProducts.Presentation.Layer.Helpers.Session;
using AsphaltsProducts.Presentation.Layer.Helpers.ComplexObjects;

namespace AsphaltsProducts.Presentation.Layer.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly ISessionFactory _session;
        public ShopController(IProductService productService, IMapper mapper, ISessionFactory session)
        {
            _mapper = mapper;
            _productService = productService;
            _session = session;
        }
        [ResponseCache(Duration = int.MaxValue,Location = ResponseCacheLocation.Any)]
        public IActionResult Index()
        {
            return Json(_mapper.Map<IList<ProductViewModel>>(_productService.GetProductsForDashboard()));
        }

        
    }
}