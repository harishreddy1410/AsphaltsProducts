using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsphaltsProducts.Service.Layer.ECommerce.ProductsService;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AsphaltsProducts.Presentation.Layer.Models;

namespace AsphaltsProducts.Presentation.Layer.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ShopController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }
        public IActionResult Index()
        {
            return Json(_mapper.Map<IList<ProductViewModel>>(_productService.GetProductsForDashboard()));
        }
    }
}