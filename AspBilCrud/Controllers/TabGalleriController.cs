using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspBilCrud.Controllers
{
    public class TabGalleriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}