using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc.Controllers
{
    public class TestController : Controller
    {

        
        public IActionResult ActionTest()
        {
            ViewData["Message"] = "Page for any notes related to ASP.Net Code MVC examples";
            
            return View();
        }


        public IActionResult ActionBootStrap()
        {
            return View();
        }
        

    }
}

