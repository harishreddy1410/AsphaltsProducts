using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AsphaltsProducts.Models;
using AsphaltsProducts.Presentation.Layer.Helpers.Session;
using Microsoft.AspNetCore.Authorization;

namespace AsphaltsProducts.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        ISessionFactory _sessionFactory;
        public HomeController(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
        public IActionResult Index()
        {
            try
            {
                _sessionFactory.Set<string>(SessionKey.SESSION_ID, "Bingo");
                var test = _sessionFactory.Get<string>(SessionKey.SESSION_ID);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }           
        }
       
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }        
    }
}
