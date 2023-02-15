﻿using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using System.Diagnostics;

namespace SalesWebMvc.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            ViewData["Message"] = "Salles Web MVC App from C# Course";
            ViewData["Email"] = "Henrique.vazquez@teste.com";
            ViewData["Studenty"] = "Henrique Vazquez";
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}