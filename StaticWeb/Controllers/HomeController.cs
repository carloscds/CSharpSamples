using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StaticWeb.Models;

namespace StaticWeb.Controllers
{
    public class HomeController : Controller
    {
        static int contador = 0;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post()
        {
            contador++;
            ViewData["contador"] = contador;
            return View("Index");
        }
    }
}
