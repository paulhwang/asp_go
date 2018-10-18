using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhwangGo.Controllers
{
    public class GoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
 
        // GET: Go
        public IActionResult GoRoot()
        {
            return View();
        }

        public IActionResult GoPlay()
        {
            return View();
        }

        public IActionResult GoSetup()
        {
            return View();
        }
    }
}