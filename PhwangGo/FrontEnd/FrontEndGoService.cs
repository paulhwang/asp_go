using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhwangGo.FrontEnd
{

    public class FabricGoServiceClass
    {
        private FrontRootClass FabricRootObject { get; }
        private int GlobalAjaxId { get; set; }

        public FabricGoServiceClass(FrontRootClass root_object_val)
        {
            this.FabricRootObject = root_object_val;
        }

        private class AjaxEntryClass
        {
            private AjaxEntryClass()
            {
                //this.theAjaxId = ajax_id_val;
                //this.theCallbackFunction = callback_func_val;
                //this.theAjaxRequest = go_request_val;
                //this.theAjaxResponse = res_val;
            }
        }

        private AjaxEntryClass MallocAjaxEntryObject(/*callback_func_val, go_request_val, res_val*/)
        {
            this.GlobalAjaxId++;
            //var ajax_id_str = this.encodeNumber(this.globalAjaxId(), this.ajaxIdSize());
            //var ajax_entry_object = new AjaxEntryClass(ajax_id_str, callback_func_val, go_request_val, res_val);
            //return ajax_entry_object;
            return null;
        }

    }
}
