﻿using Microsoft.AspNetCore.Mvc;

namespace Bangladino.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
