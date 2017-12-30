using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsphaltsProducts.Presentation.Layer.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        [Route("me")]
        [Route("\\")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}