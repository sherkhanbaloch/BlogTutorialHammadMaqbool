﻿using Microsoft.AspNetCore.Mvc;

namespace BlogTutorialHammadMaqbool.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Post()
        {
            return View();
        }
    }
}
