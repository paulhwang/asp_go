using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PhwangGo.Controllers
{
    public class AjaxController : Controller
    {
        [HttpGet]
        public string AjaxGetRequest(string var)
        {
            return AjaxCommonFunction(var);
        }

        [HttpPost]
        public string AjaxPostRequest(string var)
        {
            return AjaxCommonFunction(var);
        }

        [HttpPut]
        public string AjaxPutRequest(string var)
        {
            return AjaxCommonFunction(var);
        }

        private string AjaxCommonFunction(string var)
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
    }
}