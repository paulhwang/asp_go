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
        public string AccountSignInReq()
        {
            Fabric.FabricRootClass fabric_root = Fabric.GlobalVariableClass.getGoRoot();
            if (fabric_root == null)
            {
                return "junk";
            }
            
            Debug.WriteLine("in AccountSignInReq()");
            if (Request == null)
            {
                Debug.WriteLine("null data");
                return "null request";
            }

            string input_data = Request.Headers["phwangajaxrequest"];
            return fabric_root.ajaxFabricServiceObject.parseAjaxPacket(input_data);
        }

        public IActionResult AccountSignUp()
        {
            Debug.WriteLine("in AccountSignUp()");
            return View();
        }
    }
}
