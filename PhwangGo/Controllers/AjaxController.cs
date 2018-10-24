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
        private FrontEnd.FrontEndRootClass FabricRoot { get; }

        public AjaxController()
        {
            this.FabricRoot = GlobalVariables.GlobalVariableClass.getGoRoot();
        }

        [HttpGet]
        public string AjaxGetRequest()
        {
            return AjaxCommonFunction();
        }

        [HttpPost]
        public string AjaxPostRequest()
        {
            return AjaxCommonFunction();
        }

        [HttpPut]
        public string AjaxPutRequest()
        {
            return AjaxCommonFunction();
        }

        private string AjaxCommonFunction()
        {
            if (Request == null)
            {
                Debug.WriteLine("null Ajax request");
                return "null Ajax request";
            }

            string input_data = Request.Headers["phwangajaxrequest"];
            if (input_data == null)
            {
                Debug.WriteLine("null Ajax input_data");
                return "null Ajax input_data";

            }

            return this.FabricRoot.FabricAjaxParserObject.ProcessAjaxInput(input_data);
        }
    }
}