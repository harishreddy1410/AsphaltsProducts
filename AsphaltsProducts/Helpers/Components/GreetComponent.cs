using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsphaltsProducts.Presentation.Layer.Helpers.Components
{
    public class GreetComponent:ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            return View();
        }
    }
}
