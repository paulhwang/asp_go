using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhwangGo.Models;

namespace Phwang.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            GlobalVariables.GlobalVariableClass.getGoRoot();
        }

        public IActionResult Index()
        {
            ViewBag.phwang = "phwang";
            return View();
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
        public IActionResult HomeRoot()
        {
            ViewBag.HomeRoot = "HomeRoot";
            return View();
        }
    }
}
