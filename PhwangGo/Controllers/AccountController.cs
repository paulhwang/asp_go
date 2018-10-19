using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhwangGo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccountRoot()
        {
            Debug.WriteLine("in AccountRoot()");
            return View();
        }

        public IActionResult AccountSignIn()
        {
            Debug.WriteLine("in AccountSignIn()");
            return View();
        }

        [HttpGet]
        public IActionResult AccountSignInReq()
        {
            Debug.WriteLine("in AccountSignInReq()");
            if (Request == null)
                Debug.WriteLine("null data");
            else
            {
                //NameValueCollection header = Request.Headers;
                String data = Request.Headers["phwangajaxrequest"];
                Debug.WriteLine(data);
            }
            return View();
        }

        public IActionResult AccountSignUp()
        {
            Debug.WriteLine("in AccountSignUp()");
            return View();
        }
    }
}
